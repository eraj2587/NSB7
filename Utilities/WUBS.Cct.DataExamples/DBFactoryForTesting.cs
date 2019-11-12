using PetaPoco;
using PetaPoco.Providers;
using WUBS.ResourceAccess.CctDataRA.Model;

namespace WUBS.Cct.DataExamples
{
    internal class RueschlinkDBFactoryForTesting : RueschlinkDB.IFactory
    {
        private readonly string connectionString;

        internal RueschlinkDBFactoryForTesting(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public RueschlinkDB GetInstance()
        {
            var dbConfig = DatabaseConfiguration.Build()
                .UsingConnectionString(connectionString)
                .UsingProvider<SqlServerCEDatabaseProviders>();
            return new RueschlinkDB(dbConfig);
        }
    }

    internal class RLHistoryDBFactoryForTesting : RLHistoryDB.IFactory
    {
        private readonly string connectionString;

        internal RLHistoryDBFactoryForTesting(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public RLHistoryDB GetInstance()
        {
            var dbConfig = DatabaseConfiguration.Build()
                .UsingConnectionString(connectionString)
                .UsingProvider<SqlServerCEDatabaseProviders>();
            return new RLHistoryDB(dbConfig);
        }
    }

    internal class CrsDBFactoryForTesting : CrsDB.IFactory
    {
        private readonly string connectionString;

        internal CrsDBFactoryForTesting(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public CrsDB GetInstance()
        {
            var dbConfig = DatabaseConfiguration.Build()
                .UsingConnectionString(connectionString)
                .UsingProvider<SqlServerCEDatabaseProviders>();
            return new CrsDB(dbConfig);
        }
    }

    internal class VmarsDBFactoryForTesting : VmarsDB.IFactory
    {
        private readonly string connectionString;

        internal VmarsDBFactoryForTesting(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public VmarsDB GetInstance()
        {
            var dbConfig = DatabaseConfiguration.Build()
                .UsingConnectionString(connectionString)
                .UsingProvider<SqlServerCEDatabaseProviders>();
            return new VmarsDB(dbConfig);
        }
    }

    internal class VmsDBFactoryForTesting : VmsDB.IFactory
    {
        private readonly string connectionString;

        internal VmsDBFactoryForTesting(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public VmsDB GetInstance()
        {
            var dbConfig = DatabaseConfiguration.Build()
                .UsingConnectionString(connectionString)
                .UsingProvider<SqlServerCEDatabaseProviders>();
            return new VmsDB(dbConfig);
        }
    }
}