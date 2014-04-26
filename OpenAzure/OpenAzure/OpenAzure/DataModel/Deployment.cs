using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.DataModel
{
    public abstract class Deployment : AzureObject
    {
        public CloudServiceBase CloudService { get; set; }
        public DeploymentSlot Slot { get; set; }
    }
}
