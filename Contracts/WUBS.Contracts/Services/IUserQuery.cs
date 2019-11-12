using System.Collections.Generic;
using System.ServiceModel;
using WUBS.Contracts.Services.DataContracts;
using WUBS.Contracts.Services.DataContracts.Entities;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IUserQuery
    {
        [OperationContract]
        StaffOfficesResult GetStaffOffices(int userId, Application application);

        [OperationContract]
        List<User> GetUsersForOffice(int officeId, Application application);
    }
}
