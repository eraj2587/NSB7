using System;

namespace WUBS.Cct.Treasury.DomainModel.Enums.Utility.Exceptions
{
    public class UnexpectedCctCodeException : ApplicationException
    {
        private readonly Type enumType;
        private readonly string cctCode;

        public UnexpectedCctCodeException(string cctCode, Type enumType)
            : base(string.Format("The cctCode value {0} does not exist for specified enum {1}.", cctCode, enumType.Name))
        {
            this.enumType = enumType;
            this.cctCode = cctCode;
        }

        public Type EnumType { get { return enumType; } }
        public string CctCode { get { return cctCode; } }
    }
}
