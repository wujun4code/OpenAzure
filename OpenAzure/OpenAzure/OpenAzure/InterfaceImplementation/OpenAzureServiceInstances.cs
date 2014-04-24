using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAzure.Interface;

namespace OpenAzure.InterfaceImplementation
{
    public class OpenAzureServiceInstances
    {
        private static IOpenAzure _serviceInstance;
        public static IOpenAzure ServiceInstance 
        {
            get
            {
                if (_serviceInstance == null)
                {
                    _serviceInstance = new SimpleOpenAzure();
                }
                return _serviceInstance;
            }
            set
            {
                _serviceInstance = value;
            }
        }
    }
}
