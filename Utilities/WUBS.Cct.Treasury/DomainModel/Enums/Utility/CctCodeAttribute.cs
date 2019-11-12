using System;

namespace WUBS.Cct.Treasury.DomainModel.Enums.Utility
{
    public class CctCodeAttribute : Attribute
    {
        private string _cctCodeValue;

        public CctCodeAttribute(string value)
        {
            _cctCodeValue = value;
        }

        public string Value
        {
            get { return _cctCodeValue; }
        }

    }

}
