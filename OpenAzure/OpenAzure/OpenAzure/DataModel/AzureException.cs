using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.DataModel
{
    public class AzureException : Exception
    {
        public AzureException()
            : base()
        {

        }
        public AzureException(AzureErrorCode errorCode)
            : base()
        {
            this.ErrorCode = errorCode;
        }
        public string SubscriptionID { get; set; }
        public string ErrorMessage { get; set; }
        public HttpStatusCode API_Http_Code { get; set; }
        public AzureErrorCode ErrorCode { get; set; }
        public override string Message
        {
            get
            {
                var mes = string.Empty;
                if (ErrorCode != AzureErrorCode.None)
                {
                    mes = ErrorCode.ToString();
                }
                else
                {
                    mes = ErrorMessage;
                }
                return mes;
            }
        }

    }
    public enum AzureErrorCode : int
    {
        None,
        CertNotValid = 1,
        SubscriptionNotFound = 101,
        ServiceCreatedFailed = 201,
        ServiceNameNotValid = 202,
    }
}
