﻿using NServiceBus.Logging;

namespace WUBS.Infrastructure.Messaging
{
    public abstract class AbstractService
    {
        protected readonly ILog Logger;

        protected AbstractService()
        {
            Logger = LogManager.GetLogger(GetType());
        }

    }
}
