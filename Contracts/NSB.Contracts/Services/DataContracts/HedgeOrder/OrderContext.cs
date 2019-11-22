namespace NSB.Contracts.Services.DataContracts
{
    public class OrderContext
    {
        public string UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string BookingSource { get; set; }
        public string ExternalReference { get; set; }
        public bool IsExternal { get; set; }

        public UserType UserType { get; set; }

        public OrderContext()
        {
            
        }

        public OrderContext(string userId, string userFirstName, string userLastName, string bookingSource, string externalReference, UserType userType = UserType.Dealer, bool isExternal = false)
        {
            UserId = userId;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            BookingSource = bookingSource;
            ExternalReference = externalReference;
            UserType = userType;
            IsExternal = isExternal;
        }
    }
}
