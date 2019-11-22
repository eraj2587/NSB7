using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class User
    {
        public static readonly User SystemUser = new User { Id = 58, FirstName = "System", LastName = "User" };
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
