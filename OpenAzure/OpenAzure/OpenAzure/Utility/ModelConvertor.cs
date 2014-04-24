using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OpenAzure.Utility
{
    public class ModelConvertor
    {
        public static void MapPropteries<TSon, TBase>(TSon son, TBase father)
            where TBase : class
            where TSon : TBase
        {
            var f_type = typeof(TBase);
            var s_type = typeof(TSon);

            var f_pro_infos = f_type.GetProperties();
            var s_pro_infos = s_type.GetProperties();

            foreach (var pi in f_pro_infos)
            {
                var s_pi = s_type.GetProperty(pi.Name, pi.PropertyType);
                if (s_pi != null)
                {
                    var pi_value = pi.GetValue(father);
                    s_pi.SetValue(son, pi_value);
                }
            }
        }
    }
}
