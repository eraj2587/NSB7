using Newtonsoft.Json;
using ServiceModelEx;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WUBS.Infrastructure.Logging;

namespace WUBS.Infrastructure.Wcf.Audit
{
    public enum AuditLevel
    {
        Info,
        Detail
    }

    public class AuditInterceptor : GenericInvoker
    {
        private readonly NLog.Logger auditLogger;
        private readonly AuditLevel auditLevel;

        public AuditInterceptor(IOperationInvoker oldInvoker)
            : base(oldInvoker)
        {
            auditLogger = LogConfiguration.NLogFactoryInstance.GetLogger("Audit");
            if (!Enum.TryParse(ConfigurationManager.AppSettings["Log.Audit.Level"], out auditLevel)) auditLevel = AuditLevel.Info;
        }

        protected override void PreInvoke(object instance, object[] inputs)
        {
            Log("In", null, inputs);
        }

        protected override void PostInvoke(object instance, object returnedValue, object[] outputs, Exception exception)
        {
            var exceptionType = exception != null ? exception.GetType().FullName : null;
            var arguments = outputs.Concat(new[] { returnedValue, exception }).Where(a => a != null).ToArray();
            Log("Out", exceptionType, arguments);
        }
        private async void Log(string direction, string exceptionType, params object[] arguments)
        {
            try
            {
                var currentPrincipal = ClaimsPrincipal.Current.Identity.Name;
                var currentProcessId = Process.GetCurrentProcess().Id;
                var operationName = OperationContext.Current.IncomingMessageHeaders.Action.Substring(OperationContext.Current.IncomingMessageHeaders.Action.LastIndexOf("/", StringComparison.OrdinalIgnoreCase) + 1);
                var serviceName = OperationContext.Current.Channel.LocalAddress.Uri.ToString();
                if (exceptionType != null && auditLevel == AuditLevel.Info)
                {
                    operationName = string.Format("{0} ({1})", operationName, exceptionType);
                }
                var ip = GetClientIP();
                var sessionId = OperationContext.Current.SessionId;
                var id = (sessionId != null) ? Regex.Replace(sessionId, "[-]", string.Empty) : string.Empty;
                DateTime timestampUtc = DateTime.UtcNow;

                var sb = new StringBuilder();
                sb.AppendFormat("{7} IP={6}, ID={5}, PID={0}, UID={1}, Dir={2}, Svc={3}, Op={4}", currentProcessId, currentPrincipal, direction, serviceName, operationName, id, ip, timestampUtc.ToString("O"));
                if (auditLevel == AuditLevel.Detail)
                {
                    sb.Append(" {");
                    foreach (var arg in arguments)
                    {
                        sb.AppendFormat("\"{0}\":{1},", arg.GetType().Name, JsonConvert.SerializeObject(arg));
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append("}");
                }
                var message = sb.ToString();

                await Task.Run(() => auditLogger.Info(message));
            }
            catch (Exception)
            {
                //audit logging should not cause any failure
            }
        }

        private string GetClientIP()
        {
            var ip = "(local)";
            if (OperationContext.Current.IncomingMessageProperties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                var endpoint = OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                if (endpoint != null) ip = endpoint.Address;
            }
            return ip;
        }

    }

    public class AuditInterceptorOperationBehavior : OperationInterceptorBehaviorAttribute
    {
        protected override GenericInvoker CreateInvoker(IOperationInvoker oldInvoker)
        {
            return new AuditInterceptor(oldInvoker);
        }
    }

    public class AuditInterceptorServiceBehavior : ServiceInterceptorBehaviorAttribute
    {
        protected override OperationInterceptorBehaviorAttribute CreateOperationInterceptor()
        {
            return new AuditInterceptorOperationBehavior();
        }
    }
}
