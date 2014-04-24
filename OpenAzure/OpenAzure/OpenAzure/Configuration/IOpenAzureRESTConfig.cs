using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.Configuration
{
    public interface IOpenAzureRESTConfig
    {
        string CertFilePath { get; set; }

        string APIVersion { get; set; }
    }
}
