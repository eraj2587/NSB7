using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class Customer
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Account { get; set; }
        [DataMember] public string Code { get; set; }
        [DataMember] public string Description { get; set; }
        [DataMember] public int OfficeId { get; set; }
        [DataMember] public int ProcessCenterId { get; set; }
        [DataMember] public int RueschStaffId { get; set; }
        [DataMember] public int TypeClassification { get; set; }
        [DataMember] public int Category { get; set; }
        [DataMember] public string Email { get; set; }
        [DataMember] public string Phone { get; set; }
        [DataMember] public string FaxNumber { get; set; }
        [DataMember] public string FEIN { get; set; }
        [DataMember] public string StreetAddress1 { get; set; }
        [DataMember] public string StreetAddress2 { get; set; }
        [DataMember] public string StreetAddress3 { get; set; }
        [DataMember] public string City { get; set; }
        [DataMember] public string State { get; set; }
        [DataMember] public string Province { get; set; }
        [DataMember] public string ZipPostalCode { get; set; }
        [DataMember] public int CountryId { get; set; }
        [DataMember] public string DefaultUserFirstName { get; set; }
        [DataMember] public string DefaultUserLastName { get; set; }
        [DataMember] public int DefaultUserId { get; set; }
        [DataMember] public bool IsActive { get; set; }
        [DataMember] public int? DefaultSettlementCurrency { get; set; }
        [DataMember] public string JurisdictionCode { get; set; }
        [DataMember] public int SupportingDocumentId { get; set; }
        [DataMember] public string SupportingDocumentNumber { get; set; }
        [DataMember] public string SupportingDocumentOther { get; set; }
        [DataMember] public string IssuingAuthority { get; set; }
        [DataMember] public string LEI { get; set; }
        [DataMember] public string ParentLegalName { get; set; }
        [DataMember] public string FEINDba { get; set; }
        [DataMember] public int FEINType { get; set; }
        [DataMember] public string IncorporationStateCode { get; set; }
        [DataMember] public int StatusId { get; set; }
        [DataMember] public string ParentAddress1 { get; set; }
        [DataMember] public string ParentAddress2 { get; set; }
        [DataMember] public string ParentCity { get; set; }
        [DataMember] public int ParentCountryId { get; set; }
        [DataMember] public string ParentZip { get; set; }
        [DataMember] public string ParentState { get; set; }
        [DataMember] public int ArStatusId { get; set; }
    }
}
