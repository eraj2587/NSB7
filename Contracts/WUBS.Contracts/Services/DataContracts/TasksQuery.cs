using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public abstract class TasksQuery
    {
        [DataMember]
        public int AppId { get; set; }

    }

    [DataContract]
    public class TasksForStaffUserQuery : TasksQuery
    {
        [DataMember]
        public int UserId { get; set; }
    }


    [DataContract]
    public class TasksForApplicationUserQuery : TasksQuery
    {
        [DataMember]
        public int UserId { get; set; }
    }

}