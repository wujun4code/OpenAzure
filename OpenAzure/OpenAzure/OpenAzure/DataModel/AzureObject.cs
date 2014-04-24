using OpenAzure.Interface;
using OpenAzure.InterfaceImplementation;
using OpenAzure.StaticInstances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.DataModel
{
    public abstract class AzureObject : IGit
    {
        protected IAzureREST _rest;
        public virtual IAzureREST REST
        {
            get
            {
                if (_rest == null)
                {
                    _rest = new SimpleAzureREST();
                    _rest.ApiAddress = GetApiAddresss(AzureType);
                    _rest.APIVersion = Provider.CurrentConfig.OpenAzureRESTConfig.APIVersion;
                    _rest.CertificatePath = Provider.CurrentConfig.OpenAzureRESTConfig.CertFilePath;
                }
                return _rest;
            }
            set
            {
                _rest = value;
            }
        }

        public AzureType AzureType { get; set; }

        public virtual string GetApiAddresss(AzureType azureType)
        {
            if (azureType == 0)
            {
                return string.Empty;
            }
            string[] rtns = new string[] { ConstString.APIHOST_INTERNATIONAL, ConstString.APIHOST_CHINAMAINLAND };

            return rtns[(int)(azureType) - 1];
        }

        public abstract void Pull();

        public abstract void Push();

        public abstract void Commit();

        public abstract string APIVersion { get; set; }

    }
}
