namespace WUBS.Infrastructure.Wcf
{
    public interface IStartableServiceHost
    {
        void Start();
        void Stop();
    }
}