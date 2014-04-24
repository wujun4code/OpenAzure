using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.DataModel
{
    public abstract class Role : AzureObject
    {
        public Deployment Deployment { get; set; }

        public RoleSize Size { get; set; }

    }
}
