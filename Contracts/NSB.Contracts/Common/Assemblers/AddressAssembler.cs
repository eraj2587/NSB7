using NSB.Contracts.Services.DataContracts;

namespace NSB.Contracts.Common.Assemblers
{
    public static class AddressAssembler
    {
        public static Address Assemble(Customer customer, Country country)
        {
            return new Address
            {
                StreetAddress1 = customer.StreetAddress1,
                StreetAddress2 = customer.StreetAddress2,
                StreetAddress3 = customer.StreetAddress3,
                City = customer.City,
                ZipPostalCode = customer.ZipPostalCode,
                StateProvince = string.IsNullOrWhiteSpace(customer.State) ? customer.Province : customer.State,
                Country = country
            };
        }
    }
}
