using System.Runtime.Serialization;

namespace NSB.Contracts.Common.Validation
{
    [DataContract]
    public class ValidationError
    {
        [DataMember]
        public readonly int Code;
        [DataMember]
        public readonly string Message;

        public ValidationError(int code, params object[] information)
        {
            Code = code;
            //Message = code.FormatErrorString(null, information);
        }

        public ValidationError(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Code, Message);
        }
    }

}
