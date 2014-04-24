using OpenAzure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.StaticInstances
{
    public class Provider
    {
        private static IOpenAzureConfig _currentConfig;
        public static IOpenAzureConfig CurrentConfig
        {
            get
            {
                if (_currentConfig == null)
                {
                    _currentConfig = new SimpleOpenAzureConfig();
                    _currentConfig.LoadConfig();
                }
                return _currentConfig;
            }
        
        }
    }
}
