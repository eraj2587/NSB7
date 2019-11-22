using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class PostalAddress
    {
        private string _postalCode;
        private string _city;
        private string _provinceState;

        [XmlElement("PstCd")]
        [MinLength(1), MaxLength(16)]
        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = string.IsNullOrEmpty(value) ? null : value.Length > 16 ? value.Substring(0, 16) : value; }
        }

        [XmlElement("TwnNm")]
        [MinLength(1), MaxLength(35)]
        public string City
        {
            get { return _city; }
            set { _city = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }

        [XmlElement("CtrySubDvsn")]
        [MinLength(1), MaxLength(35)]
        public string ProvinceState
        {
            get { return _provinceState; }
            set { _provinceState = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }

        [XmlElement("Ctry")]
        [RegularExpression(@"[A-Z]{2,2}")]
        public string Country { get; set; }

        [XmlElement("AdrLine")]
        [MinLength(1), MaxLength(70)]
        public List<string> AddressLine { get; set; }
    }
}
