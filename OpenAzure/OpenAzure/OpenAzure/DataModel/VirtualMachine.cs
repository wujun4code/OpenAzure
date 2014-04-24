using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.DataModel
{
    public class VirtualMachine : Role
    {
        public override void Commit()
        {
            throw new NotImplementedException();
        }

        public override void Pull()
        {
            throw new NotImplementedException();
        }

        public override void Push()
        {
            throw new NotImplementedException();
        }

        public override string APIVersion
        {
            get
            {
                return ConstString.API_VERSION_DATE_2013_11_01;
            }
            set
            {

            }
        }
    }
}
