using System.ComponentModel;
using System.Configuration.Install;
using System.Reflection;
using System.ServiceProcess;

namespace NSB.Endpoints.Server
{
    [RunInstaller(true)]
    public class WinServiceInstaller: Installer
    {
        public WinServiceInstaller()
        {
            var spi = new ServiceProcessInstaller();
            var si = new ServiceInstaller();

            spi.Account = ServiceAccount.LocalSystem;
            spi.Username = null;
            spi.Password = null;

            si.DisplayName = Assembly.GetExecutingAssembly().GetName().Name;
            si.ServiceName = Assembly.GetExecutingAssembly().GetName().Name;
            si.StartType = ServiceStartMode.Automatic;
            
           

            Installers.Add(spi);
            Installers.Add(si);
        }
    }
}
