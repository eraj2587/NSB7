using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace WUBS.Cct.DataExamples.TestDataContainer
{
    public abstract class AbstractOrderData : IDisposable
    {
        private List<StaticDataDatabase> dbs = new List<StaticDataDatabase>();

        protected StaticDataDatabase AddDatabase(StaticDataDatabase staticDataDatabase)
        {
            dbs.Add(staticDataDatabase);

            return staticDataDatabase;
        }

        public StaticDataDatabase GetDatabase(string name)
        {
            return dbs.FirstOrDefault(db => db.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public void AddRecord(StaticDataRow row)
        {
            GetDB(row).AddRow(row);
        }

        public void AddRecord(IEnumerable<StaticDataRow> rows)
        {
            foreach (var row in rows)
                AddRecord(row);
        }

        private StaticDataDatabase GetDB(StaticDataRow row)
        {
            return dbs.First(db => db.AcceptsRow(row));
        }

        public void Dispose()
        {
            foreach (var db in dbs)
                db.Dispose();
        }
    }

    public abstract class StaticDataDatabase : DataContext
    {
        private readonly SqlCeConnection connection;
        private static string ConnectionStringFormat = "Data Source=\"{0}\"";
        private string dbFilename;

        //tablename, table instance
        public Dictionary<string, StaticDataTable> Tables { get; private set; }

        public abstract string Name { get; }

        public StaticDataDatabase() : this(Path.GetRandomFileName() + ".sdf")
        {
            Tables = new Dictionary<string, StaticDataTable>();
        }

        public StaticDataDatabase(string filename)
            : this(new SqlCeConnection(string.Format(ConnectionStringFormat, filename)))
        {
            dbFilename = filename;
            CreateDatabase();
        }

        public StaticDataDatabase(SqlCeConnection connection) : base(connection)
        {
            this.connection = connection;
        }

        public string ConnectionString { get { return string.Format(ConnectionStringFormat, dbFilename); } }

        public bool AcceptsRow(StaticDataRow row)
        {
            return Tables.Values.Any(table => table.AcceptsRow(row));
        }

        public bool AcceptsRowType(Type rowType)
        {
            return Tables.Values.Any(table => table.AcceptsRowType(rowType));
        }

        public StaticDataDatabase AddRow<TRow>(TRow row)
            where TRow : StaticDataRow
        {
            var table = this.GetTable<TRow>();
            table.InsertOnSubmit(row);
            this.SubmitChanges();

            return this;
        }

        public StaticDataDatabase AddRows<TRow>(IEnumerable<TRow> rows)
            where TRow : StaticDataRow
        {
            var table = this.GetTable<TRow>();
            table.InsertAllOnSubmit(rows);
            this.SubmitChanges();

            return this;
        }

        protected void InsertStaticData()
        {
            foreach (var table in Tables)
                foreach (var row in table.Value.Rows)
                {
                    dynamic dynamicRow = row;
                    this.AddRow(dynamicRow);
                }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            connection.Dispose();

            try
            {
                if (File.Exists(dbFilename))
                {
                    File.Delete(dbFilename);
                }
                else
                {
                    Debug.WriteLine(string.Format("InMemoryDataContext SQL Server CE file cannot be found {0}", dbFilename));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("Exception while deleting SQL Server CE file {0}", dbFilename));
                Debug.WriteLine(ex.ToString());
            }
        }
    }

    public abstract class StaticDataTable
    {
        public abstract string Name { get; }
        public abstract Type RowType { get; }
        public List<StaticDataRow> Rows { get; private set; }

        public StaticDataTable()
        {
            Rows = new List<StaticDataRow>();
        }

        public bool AcceptsRow(StaticDataRow row)
        {
            return AcceptsRowType(row.GetType());
        }

        public bool AcceptsRowType(Type rowType)
        {
            return rowType == RowType;
        }

        public void AddRow(StaticDataRow row)
        {
            Rows.Add(row);
        }
    }

    public abstract class StaticDataRow
    {
        //colname, colvalue
        protected Dictionary<string, ValueContainer> ColsAndValues { get; private set; }

        public StaticDataRow()
        {
            ColsAndValues = new Dictionary<string, ValueContainer>();
        }
    }

    public class ValueContainer
    {
        public static ValueContainer Null = new ValueContainer();
        public Type Type;
        public object Value;
    }
}