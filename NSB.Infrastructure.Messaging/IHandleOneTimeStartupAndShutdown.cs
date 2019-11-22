using System.Threading.Tasks;

namespace NSB.Infrastructure.Messaging
{
    public interface IHandleOneTimeStartupAndShutdown
    {
        Task Startup();
        Task Shutdown();
    }
}
