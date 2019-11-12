using NServiceBus;

namespace WUBS.Contracts.Commands
{
    public class BankHolidayCommand : ICommand
    {
        public string CCTBankHolidayId { get; set; }
        public string CurrencyCode { get; set; }
        public string CountryCode { get; set; }
        public string HolidayDate { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string TriggerType { get; set; }
    }

    public class WindowsTimeZoneCommand : ICommand
    {
        public string WindowsTimeZoneId { get; set; }
        public string Description { get; set; }
        public string StandardName { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string TriggerType { get; set; }
    }



    public class NostroBankAccountCommand : ICommand
    {
        public string CctNostroBankAccountId { get; set; }
        public string NostroBankAccountCode { get; set; }
        public string BankName { get; set; }
        public string CurrencyCode { get; set; }
        public string CountryCode { get; set; }
        public string CountryHolidayApplicable { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string TriggerType { get; set; }
    }

    public class NostroBankAccountChannelCommand : ICommand
    {
        public string CctNostroBankAccountChannelId { get; set; }
        public string CctNostroBankAccountId { get; set; }
        public string ClearingTypeId { get; set; }
        public string IsOutgoingPayment { get; set; }
        public string PreferredMsgFormat { get; set; }
        public string ProcessingDays { get; set; }
        public string TimeZoneId { get; set; }
        public string AutoReleaseStartDateTime { get; set; }
        public string ReleaseDeadlineDateTime { get; set; }
        public string ChannelBusinessDays { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string TriggerType { get; set; }
    }
}