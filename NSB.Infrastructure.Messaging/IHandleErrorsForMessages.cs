using System;

namespace NSB.Infrastructure.Messaging
{
    public interface IHandleErrorsForMessages
    {
        Type ForMessageType { get; }

        void MessageSentToErrorQueue(object message, Exception ex);
    }

    public abstract class AbstractErrorHandler<T> : IHandleErrorsForMessages
        where T : class
    {
        public Type ForMessageType { get { return typeof(T); } }

        public void MessageSentToErrorQueue(object message, Exception ex)
        {
            var typedMessage = message as T;
            if (null != typedMessage)
                MessageSentToErrorQueue(typedMessage, ex);
        }

        protected abstract void MessageSentToErrorQueue(T message, Exception ex);

    }
}
