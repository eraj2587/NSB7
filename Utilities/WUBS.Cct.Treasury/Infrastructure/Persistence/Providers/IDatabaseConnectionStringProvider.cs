using WUBS.Cct.Treasury.Infrastructure.Persistence.DB;

namespace WUBS.Cct.Treasury.Infrastructure.Persistence.Providers
{
    public interface IDatabaseConnectionStringProvider
    {
        string GetDatabaseConnectionString(Database database);
    }
}
