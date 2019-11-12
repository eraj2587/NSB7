using System;
using System.Threading.Tasks;
using NServiceBus;
namespace WUBS.Infrastructure.Messaging
{
    public static class Extensions
    {
        //IEndpoint instance method to be called with more parameters

        //commands
        public static Task SendCommand<TCommand>(this IEndpointInstance instance,TCommand command)
        {
           instance.Send(command).ConfigureAwait(false).GetAwaiter().GetResult();
           return Task.CompletedTask;
        }

        public static Task SendCommand(this IEndpointInstance instance, object command)
        {
            instance.Send(command).ConfigureAwait(false).GetAwaiter().GetResult();
            return Task.CompletedTask;
        }

        public static Task SendCommand<TCommand>(this IEndpointInstance instance, Action<TCommand> messageConstructor)
        {
            instance.Send(messageConstructor).ConfigureAwait(false).GetAwaiter().GetResult();
            return Task.CompletedTask;
        }

        public static async Task SendCommandAsync<TCommand>(this IEndpointInstance instance, TCommand command)
        {
           await instance.Send(command).ConfigureAwait(false);
        }

        public static async Task SendCommandAsync(this IEndpointInstance instance, object command)
        {
           await instance.Send(command).ConfigureAwait(false);
        }

        public static async Task SendCommandAsync<TCommand>(this IEndpointInstance instance, Action<TCommand> messageConstructor)
        {
           await instance.Send(messageConstructor).ConfigureAwait(false);
        }

        //publish

        public static Task PublishEvent<TEvent>(this IEndpointInstance instance, TEvent message)
        {
            instance.Publish(message).ConfigureAwait(false).GetAwaiter().GetResult();
            return Task.CompletedTask;
        }

        public static Task PublishEvent(this IEndpointInstance instance, object message)
        {
            instance.Publish(message).ConfigureAwait(false).GetAwaiter().GetResult();
            return Task.CompletedTask;
        }

        public static Task PublishEvent<TEvent>(this IEndpointInstance instance, Action<TEvent> messageConstructor)
        {
            instance.Publish(messageConstructor).ConfigureAwait(false).GetAwaiter().GetResult();
            return Task.CompletedTask;
        }

        public static async Task PublishEventAsync<TEvent>(this IEndpointInstance instance, TEvent message)
        {
            await instance.Publish(message).ConfigureAwait(false);
        }

        public static async Task PublishEventAsync(this IEndpointInstance instance, object message)
        {
            await instance.Publish(message).ConfigureAwait(false);
        }

        public static async Task PublishEventAsync<TEvent>(this IEndpointInstance instance, Action<TEvent> messageConstructor)
        {
            await instance.Publish(messageConstructor).ConfigureAwait(false);
        }


        //IMessageHandlerContext


        //commands
        public static Task SendCommand<TCommand>(this IMessageHandlerContext context, TCommand command)
        {
            context.Send(command).ConfigureAwait(false).GetAwaiter().GetResult();
            return Task.CompletedTask;
        }

        public static Task SendCommand(this IMessageHandlerContext context, object command)
        {
            context.Send(command).ConfigureAwait(false).GetAwaiter().GetResult();
            return Task.CompletedTask;
        }

        public static Task SendCommand<TCommand>(this IMessageHandlerContext context, Action<TCommand> messageConstructor)
        {
            context.Send(messageConstructor).ConfigureAwait(false).GetAwaiter().GetResult();
            return Task.CompletedTask;
        }

        public static async Task SendCommandAsync<TCommand>(this IMessageHandlerContext context, TCommand command)
        {
            await context.Send(command).ConfigureAwait(false);
        }

        public static async Task SendCommandAsync(this IMessageHandlerContext context, object command)
        {
            await context.Send(command).ConfigureAwait(false);
        }

        public static async Task SendCommandAsync<TCommand>(this IMessageHandlerContext context, Action<TCommand> messageConstructor)
        {
            await context.Send(messageConstructor).ConfigureAwait(false);
        }


        //publish

        public static Task PublishEvent<TEvent>(this IMessageHandlerContext context, TEvent message)
        {
            context.Publish(message).ConfigureAwait(false).GetAwaiter().GetResult();
            return Task.CompletedTask;
        }

        public static Task PublishEvent(this IMessageHandlerContext context, object message)
        {
            context.Publish(message).ConfigureAwait(false).GetAwaiter().GetResult();
            return Task.CompletedTask;
        }

        public static Task PublishEvent<TEvent>(this IMessageHandlerContext context, Action<TEvent> messageConstructor)
        {
            context.Publish(messageConstructor).ConfigureAwait(false).GetAwaiter().GetResult();
            return Task.CompletedTask;
        }

        public static async Task PublishEventAsync<TEvent>(this IMessageHandlerContext context, TEvent message)
        {
            await context.Publish(message).ConfigureAwait(false);
        }

        public static async Task PublishEventAsync(this IMessageHandlerContext context, object message)
        {
            await context.Publish(message).ConfigureAwait(false);
        }

        public static async Task PublishEventAsync<TEvent>(this IMessageHandlerContext context, Action<TEvent> messageConstructor)
        {
            await context.Publish(messageConstructor).ConfigureAwait(false);
        }




    }
}
