using System.Collections.Generic;
using System.ServiceModel;
using NSB.Contracts.Services.DataContracts;
using NSB.Contracts.Services.DataContracts.Entities;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
    public interface IUserQuery
    {
        [OperationContract]
        StaffOfficesResult GetStaffOffices(int userId, Application application);

        [OperationContract]
        List<User> GetUsersForOffice(int officeId, Application application);
    }
}
