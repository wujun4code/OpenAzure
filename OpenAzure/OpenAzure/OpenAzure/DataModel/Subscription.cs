using OpenAzure.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.DataModel
{
    public abstract class SubscriptionBase : AzureObject
    {
        public string SubscriptionID { get; set; }

        public string SubscriptionName { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public int CPUCoresQuota { get; set; }

        public int StorageAccountQuota { get; set; }

        public int HostedServicesQuota { get; set; }

        public int CPUCoresUsage { get; set; }

        public int StorageAccountUsage { get; set; }

        public int HostedServicesUsage { get; set; }

        public DateTime CreatedTime { get; set; }

       

        public IEnumerable<CloudService> HostedCloudServices { get; set; }

        public override string APIVersion
        {
            get
            {
                return ConstString.API_VERSION_DATE_2013_11_01;
            }
            set
            {

            }
        }

    }

    public class Subscription : SubscriptionBase
    {
        public override void Commit()
        {
            throw new NotSupportedException();
        }

        public override void Pull()
        {
            var father = this.REST.GetAzureSubscriptionInfo(this.SubscriptionID);

            ModelConvertor.MapPropteries<Subscription, SubscriptionBase>(this, father);
        }

        public override void Push()
        {
            throw new NotSupportedException();
        }
    }
}
