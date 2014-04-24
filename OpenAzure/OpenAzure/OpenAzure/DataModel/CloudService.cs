using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.DataModel
{
    public abstract class CloudService : AzureObject
    {
        public string Name { get; set; }

        public string DNSName { get; set; }

        public SubscriptionBase Subscription { get; set; }

        public IEnumerable<Deployment> Deployments { get; set; }

    }
}
