using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.MakeCert
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Process();
            p.StartInfo.FileName = GetMakeCertCommandPath();
            p.StartInfo.Arguments = "-sky exchange -r -n CN=MBPVM -pe -a sha1 -len 2048 -ss My MBPVM.cer";
            p.Start();
        }
        public static string GetMakeCertCommandPath()
        {
            var rtn = string.Empty;

            if(Environment.Is64BitOperatingSystem)
            {
                rtn = "C:\\Program Files (x86)\\Microsoft SDKs\\Windows\\v7.1A\\Bin\\x64\\makecert.exe";
            }
            return rtn;
        }
    }
}
