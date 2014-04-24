using OpenAzure.StaticInstances;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.Configuration
{
    public class SimpleOpenAzureConfig : IOpenAzureConfig
    {
        public void LoadConfig()
        {
            Config = (OpenAzureConfigurationSection)ConfigurationManager.GetSection(OpenAzureDic.ConfigSectionKey);
        }
        public OpenAzureConfigurationSection Config { get; set; }
        public IOpenAzureRESTConfig OpenAzureRESTConfig
        {
            get
            {
                return Config.RESTConfig;
            }
            set
            {

            }
        }
    }

    public class OpenAzureConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty(OpenAzureDic.REST_Config_Key, IsRequired = true)]
        public OpenAzureRESTElement RESTConfig
        {
            get
            {
                return base[OpenAzureDic.REST_Config_Key] as OpenAzureRESTElement;
            }
        }
    }


    public class OpenAzureRESTElement : ConfigurationElement, IOpenAzureRESTConfig
    {
        [ConfigurationProperty(OpenAzureDic.REST_Version_Key, IsRequired = true)]
        public string APIVersion
        {
            get
            {
                return base[OpenAzureDic.REST_Version_Key] as string;
            }
            set
            {
                base[OpenAzureDic.REST_Version_Key] = value;
            }
        }

        [ConfigurationProperty(OpenAzureDic.REST_Certificate_Key, IsRequired = true)]
        public string CertFilePath
        {
            get
            {
                return base[OpenAzureDic.REST_Certificate_Key] as string;
            }
            set
            {
                base[OpenAzureDic.REST_Certificate_Key] = value;
            }
        }
    }
}
