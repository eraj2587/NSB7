using System.Threading.Tasks;

namespace WUBS.Infrastructure.Messaging
{
    public interface IHandleOneTimeStartupAndShutdown
    {
        Task Startup();
        Task Shutdown();
    }
}
