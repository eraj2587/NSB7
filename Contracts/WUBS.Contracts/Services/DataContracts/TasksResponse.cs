using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class TasksResponse
    {
        public IEnumerable<Task> Tasks { get; set; }
    }
}