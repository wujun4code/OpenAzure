using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.Configuration
{
    public interface IOpenAzureConfig
    {
        void LoadConfig();
        IOpenAzureRESTConfig OpenAzureRESTConfig { get; set; }
    }
}
