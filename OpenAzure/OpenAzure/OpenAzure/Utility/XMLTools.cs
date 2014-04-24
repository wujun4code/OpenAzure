using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OpenAzure.Utility
{
    public class XMLTools
    {
        public static XElement GetElementFromXML(string XMLString, string elName)
        {
            var xmlContentDoc = System.Xml.Linq.XDocument.Parse(XMLString);
            var rootNode = xmlContentDoc.Root;
            XNamespace xmlns = rootNode.Name.Namespace;

            var rtn = rootNode.Element(xmlns + elName);

            return rtn;
        }
    }
}
