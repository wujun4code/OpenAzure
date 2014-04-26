using OpenAzure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.Interface
{
    public interface IAzureREST
    {
        string CertificatePath { get; set; }

        string ApiAddress { get; set; }

        string APIVersion { get; set; }

        SubscriptionBase GetAzureSubscriptionInfo(string SubscriptionID);

        CloudServiceBase GetAzureCloudServiceInfo(string SubscriptionID, string CloudServiceName);
    }
}
