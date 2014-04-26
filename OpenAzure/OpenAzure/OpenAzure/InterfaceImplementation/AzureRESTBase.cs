using OpenAzure.DataModel;
using OpenAzure.Interface;
using OpenAzure.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.InterfaceImplementation
{
    public abstract class AzureRESTBase : IAzureREST
    {
        #region properties
        private string _certificatePath;
        public string CertificatePath
        {
            get
            {
                return _certificatePath;
            }
            set
            {
                _certificatePath = value;
            }
        }

        private string _apiAddress;
        public string ApiAddress
        {
            get
            {
                return _apiAddress;
            }
            set
            {
                _apiAddress = value;
            }
        }
        private string _apiVersion;
        public string APIVersion
        {
            get
            {
                return _apiVersion;
            }
            set
            {
                _apiVersion = value;
            }
        }
        #endregion


        #region impls

        public virtual SubscriptionBase GetAzureSubscriptionInfo(string SubscriptionID)
        {
            SubscriptionBase rtn = new Subscription();

            var rep = GetAzureSubscriptionRep(SubscriptionID);
            if (rep.StatusCode == HttpStatusCode.Forbidden || rep.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new AzureException(AzureErrorCode.SubscriptionNotFound);
            }
            else
            {
                var maxCPUCores = XMLTools.GetElementFromXML(rep.Content, "MaxCoreCount");
                var name = XMLTools.GetElementFromXML(rep.Content, "SubscriptionName");
                var id = XMLTools.GetElementFromXML(rep.Content, "SubscriptionID");
                var status = XMLTools.GetElementFromXML(rep.Content, "SubscriptionStatus");
                var MaxStorageAccounts = XMLTools.GetElementFromXML(rep.Content, "MaxStorageAccounts");
                var MaxHostedServices = XMLTools.GetElementFromXML(rep.Content, "MaxHostedServices");
                var CurrentCoreCount = XMLTools.GetElementFromXML(rep.Content, "CurrentCoreCount");
                var CurrentHostedServices = XMLTools.GetElementFromXML(rep.Content, "CurrentHostedServices");
                var CurrentStorageAccounts = XMLTools.GetElementFromXML(rep.Content, "CurrentStorageAccounts");
                var MaxVirtualNetworkSites = XMLTools.GetElementFromXML(rep.Content, "MaxVirtualNetworkSites");
                var CurrentVirtualNetworkSites = XMLTools.GetElementFromXML(rep.Content, "CurrentVirtualNetworkSites");
                var MaxLocalNetworkSites = XMLTools.GetElementFromXML(rep.Content, "MaxLocalNetworkSites");
                var MaxDnsServers = XMLTools.GetElementFromXML(rep.Content, "MaxDnsServers");
                var AADTenantID = XMLTools.GetElementFromXML(rep.Content, "AADTenantID");
                var CreatedTime = XMLTools.GetElementFromXML(rep.Content, "CreatedTime");

                rtn.SubscriptionID = id.Value;
                rtn.SubscriptionName = name.Value;
                rtn.Status = status.Value;
                rtn.CreatedTime = DateTime.Parse(CreatedTime.Value);
                rtn.CPUCoresQuota = int.Parse(maxCPUCores.Value);
                rtn.StorageAccountQuota = int.Parse(MaxStorageAccounts.Value);
                rtn.HostedServicesQuota = int.Parse(MaxHostedServices.Value);

                rtn.CPUCoresUsage = int.Parse(CurrentCoreCount.Value);
                rtn.StorageAccountUsage = int.Parse(CurrentStorageAccounts.Value);
                rtn.HostedServicesUsage = int.Parse(CurrentHostedServices.Value);
            }

            return rtn;

        }

        public virtual CloudServiceBase GetAzureCloudServiceInfo(string SubscriptionID, string CloudServiceName)
        {
            CloudServiceBase rtn = null;
            IDictionary<string, string> ps = new Dictionary<string, string>();
            ps.Add("embed-detail", "true");
            var rep = ExcuteGet(ps, ConstString.Request_URI_CloudService, SubscriptionID, CloudServiceName);




            return rtn;
        }

        #endregion
        protected virtual IRestResponse GetAzureSubscriptionRep(string SubscriptionID)
        {
            var req = GetCommonReq();
            req.Resource = SubscriptionID;
            var rep = Excute(req);
            return rep;
        }

        protected virtual IRestResponse ExcuteGet(IDictionary<string, string> Parameters, string ResourceTemplate, params string[] ResourceArgs)
        {
            var req = GetCommonReq();
            req.Resource = string.Format(ResourceTemplate, ResourceArgs);
            req.Method = Method.GET;

            if (Parameters != null)
            {
                foreach (var pm in Parameters)
                {
                    req.AddParameter(pm.Key, pm.Value);
                }
            }
            var rep = Excute(req);
            return rep;
        }

        public virtual IRestResponse Excute(RestRequest req)
        {
            RestClient client = GetAzureRestClient(this.ApiAddress, this.CertificatePath);

            var rep = client.Execute(req);
            GetError(rep);
            return rep;

        }

        public virtual RestRequest GetCommonReq()
        {
            var req = new RestRequest();

            req.AddHeader("Content-Type", "application/xml");

            return req;
        }

        public void GetError(IRestResponse rep)
        {
            if (rep.StatusCode == HttpStatusCode.Accepted
                || rep.StatusCode == HttpStatusCode.OK ||
                rep.StatusCode == HttpStatusCode.Created)
            {

            }
            else
            {
                new AzureException() { API_Http_Code = rep.StatusCode };
            }
        }

        public virtual RestClient GetAzureRestClient(string ApiAddresss, string certPath)
        {
            RestClient client = new RestClient(ApiAddresss);
            client.AddDefaultHeader("x-ms-version", this.APIVersion);
            string servicePath = AppDomain.CurrentDomain.BaseDirectory;
            string certificatePath = servicePath + certPath;
            X509Certificate2 myCert = new X509Certificate2(certPath);
            client.ClientCertificates = new X509CertificateCollection();
            client.ClientCertificates.Add(myCert);
            return client;
        }
    }
}
