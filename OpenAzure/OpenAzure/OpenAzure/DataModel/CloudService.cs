using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.DataModel
{
    public abstract class CloudServiceBase : AzureObject
    {
        public string Name { get; set; }

        public string DNSName { get; set; }

        public SubscriptionBase Subscription { get; set; }

        public IEnumerable<Deployment> Deployments { get; set; }

        public override AzureType AzureType
        {
            get
            {
                return Subscription.AzureType;
            }
            set
            {

            }
        }

    }

    public class CloudService : CloudServiceBase
    {
        public override void Push()
        {
            throw new NotImplementedException();
        }

        public override void Pull()
        {
            this.REST.GetAzureCloudServiceInfo(this.Subscription.SubscriptionID, this.Name);
        }

        public override void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
