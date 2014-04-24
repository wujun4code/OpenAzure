using Microsoft.WindowsAzure.Management.Subscription;
using OpenAzure.Configuration;
using OpenAzure.DataModel;
using OpenAzure.InterfaceImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzureDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Subscription sub = new Subscription();
            sub.AzureType = AzureType.ChinaMainland;
            sub.SubscriptionID = "be6d343c-b79f-4a47-b7f5-bc63d725dbeb";

            sub.Pull();

            var dd = sub.Status;

        }
    }
}
