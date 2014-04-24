using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.DataModel
{
    public enum RoleType
    {
        WebRole = 1,
        WorkRole = 2,
        VirtualMachine = 3
    }
    public enum DeploymentSlot
    {
        Production = 1,
        Staging = 2
    }
    public enum AzureType : int
    {
        International = 1,
        ChinaMainland = 2
    }
    public enum OSType
    {
        Windows = 1,
        Linux = 2
    }
    public enum APIVersionDate
    {

    }
}
