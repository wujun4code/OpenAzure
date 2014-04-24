using OpenAzure.Configuration;
using OpenAzure.Interface;
using OpenAzure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.InterfaceImplementation
{
    public class SimpleOpenAzure : IOpenAzure
    {
        private IAzureREST _restService;
        public IAzureREST RESTService
        {
            get
            {
                if (_restService == null)
                {
                    _restService = new SimpleAzureREST();
                }
                return _restService;
            }
            set
            {
                _restService = value;
            }
        }

        private IOpenAzureConfig _config;
        public IOpenAzureConfig Config
        {
            get
            {
                if (_config == null)
                {
                    _config = new SimpleOpenAzureConfig();
                }
                return _config;
            }
            set
            {
                _config = value;
            }
        }

        public SubscriptionBase GetSubscription(SubscriptionBase subscription)
        {
            SubscriptionBase rtn = null;
            
            rtn = RESTService.GetAzureSubscriptionInfo(subscription.SubscriptionID);
            return rtn;
        }
    }
}
