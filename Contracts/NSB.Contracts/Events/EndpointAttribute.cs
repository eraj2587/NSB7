using System;

namespace NSB.Contracts.Events
{
    public class EndpointAttribute : Attribute
    {
        public string PublishingEndpointName { get; private set; }

        public EndpointAttribute(string publishingEndpointName)
        {
            PublishingEndpointName = publishingEndpointName;
        }
    }
}