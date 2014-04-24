using OpenAzure.Configuration;
using OpenAzure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.Interface
{
    public interface IOpenAzure
    {

        SubscriptionBase GetSubscription(SubscriptionBase subscription);

        IOpenAzureConfig Config { get; set; }

        IAzureREST RESTService { get; set; }
    }
}
