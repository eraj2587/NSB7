using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using WUBS.Contracts.Commands;
using WUBS.Infrastructure.Messaging.Messages;
using Autofac;

namespace WUBS.Infrastructure.Messaging
{
    public abstract class ScheduledTaskDefinition : IScheduledTask, IHandleOneTimeStartupAndShutdown
    {
        IEndpointInstance instance;
        public ScheduledTaskDefinition(IEndpointInstance instance)
        {
            this.instance = instance;
        }

        public Task Startup()
        {
            if (IsEnabled)
                instance.SendLocal(new BeginScheduledTask
                {
                    TaskTypeFullName = this.GetType().FullName,
                    WaitDuration = WaitDuration
                }).ConfigureAwait(false).GetAwaiter().GetResult();
            else
                instance.SendLocal(new StopScheduledTask
                {
                    TaskTypeFullName = this.GetType().FullName
                }).ConfigureAwait(false).GetAwaiter().GetResult();
            return Task.CompletedTask;
        }

        public Task Shutdown()
        {
            return Task.CompletedTask;
        }

        public abstract bool Run();

        public abstract TimeSpan WaitDuration { get; }
        public abstract bool IsEnabled { get; }

    }

    public class ScheduledTaskExecutor :
        Saga<ScheduledTaskSagaData>,
        IAmStartedByMessages<BeginScheduledTask>,
        IHandleTimeouts<ScheduledTaskTimeout>,
        IHandleMessages<StopScheduledTask>
    {
        private readonly Dictionary<string, IScheduledTask> scheduledTasksByType;
        private readonly ILog logger = LogManager.GetLogger<ScheduledTaskExecutor>();
        public IContainer Container { get; set; }
        public IScheduledTask[] scheduledTasks { get; set; }

        public ScheduledTaskExecutor()
        {
            // Container = _container;
            // var scheduledTasks = Container.Resolve<IScheduledTask[]>();
            scheduledTasksByType = scheduledTasks.ToDictionary(t => t.GetType().FullName, t => t);
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<ScheduledTaskSagaData> mapper)
        {
            mapper.ConfigureMapping<BeginScheduledTask>(m => m.TaskTypeFullName).ToSaga(s => s.TaskTypeFullName);
            mapper.ConfigureMapping<StopScheduledTask>(m => m.TaskTypeFullName).ToSaga(s => s.TaskTypeFullName);
        }

        public Task Handle(BeginScheduledTask message, IMessageHandlerContext context)
        {
            Data.WaitDuration = message.WaitDuration;

            Data.TaskTypeFullName = message.TaskTypeFullName;

            var timeoutMessage = new ScheduledTaskTimeout
            {
                TaskTypeFullName = message.TaskTypeFullName
            };

            Data.TimeoutIdentifier = timeoutMessage.Identifier;

            return RequestTimeout<ScheduledTaskTimeout>(context, DateTime.Now, timeoutMessage);
        }

        public Task Handle(StopScheduledTask message, IMessageHandlerContext context)
        {
            MarkAsComplete();
            return Task.CompletedTask;
        }

        public Task Timeout(ScheduledTaskTimeout state, IMessageHandlerContext context)
        {
            MarkAsComplete();
            if (Data.TimeoutIdentifier != state.Identifier) return Task.CompletedTask; ;

            var scheduledTask = GetScheduledTask(state.TaskTypeFullName);

            //zombie timeout, no scheduled task matches the timer's task 
            if (null == scheduledTask) { MarkAsComplete(); return Task.CompletedTask; }

            //zombie timeout, scheduled task is not enabled to run
            if (!scheduledTask.IsEnabled) return Task.CompletedTask;

            var noWait = false;
            try
            {
                using (
                    var tx = new TransactionScope(TransactionScopeOption.RequiresNew,
                        new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted },
                        TransactionScopeAsyncFlowOption.Enabled))
                {
                    noWait = scheduledTask.Run();

                    tx.Complete();
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Scheduled task <{0}> has failed with exception: {1}", state.TaskTypeFullName, ex.ToString());
            }

            var timeout = new ScheduledTaskTimeout
            {
                TaskTypeFullName = state.TaskTypeFullName,
            };
            Data.TimeoutIdentifier = timeout.Identifier;

            return RequestTimeout(context,
                 noWait ? DateTime.Now : DateTime.Now.AddSeconds(Data.WaitDuration.TotalSeconds),
                 timeout);
        }

        private IScheduledTask GetScheduledTask(string taskTypeFullName)
        {
            if (scheduledTasksByType != null && scheduledTasksByType.ContainsKey(taskTypeFullName))
                return scheduledTasksByType[taskTypeFullName];

            return null;
        }
    }

    public class ScheduledTaskTimeout
    {

        public ScheduledTaskTimeout()
        {
            Identifier = Guid.NewGuid().ToString("N");
        }
        public string TaskTypeFullName { get; set; }
        public string Identifier { get; set; }
    }

    public class ScheduledTaskSagaData : ContainSagaData
    {
        public virtual string TaskTypeFullName { get; set; }

        public virtual TimeSpan WaitDuration { get; set; }
        public virtual string TimeoutIdentifier { get; set; }
    }
}
