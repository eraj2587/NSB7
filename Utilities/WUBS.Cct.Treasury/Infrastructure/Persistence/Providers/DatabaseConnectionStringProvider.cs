using System;
using WUBS.Cct.Treasury.Infrastructure.Persistence.DB;

namespace WUBS.Cct.Treasury.Infrastructure.Persistence.Providers
{
    public class DatabaseConnectionStringProvider : IDatabaseConnectionStringProvider
    {
        private static IDatabaseConnectionStringProvider instance;
        public static IDatabaseConnectionStringProvider Instance
        {
            get { return instance ?? (instance = new DatabaseConnectionStringProvider()); }
            set { instance = value; }
        }

        private DatabaseConnectionStringProvider() { }

        public string GetDatabaseConnectionString(Database database)
        {
            switch (database)
            {
                case Database.RueschLink:
                    return AppConfigDatabaseConnectionStrings.RueschLink;
                case Database.Crs:
                    return AppConfigDatabaseConnectionStrings.CRS;
                case Database.History:
                    return AppConfigDatabaseConnectionStrings.History;
                case Database.Vmars:
                    return AppConfigDatabaseConnectionStrings.Vmars;
                case Database.Vms:
                    return AppConfigDatabaseConnectionStrings.Vms;
                case Database.NostroSubsidiary:
                    return AppConfigDatabaseConnectionStrings.NostroSubsidiary;
                default:
                    throw new InvalidOperationException("Attempted to retrieve connection string for unknown database.");       
            }    
        }
    }
}
