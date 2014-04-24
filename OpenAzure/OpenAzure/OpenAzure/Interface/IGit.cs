using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAzure.Interface
{
    public interface IGit
    {
        void Pull();

        void Push();

        void Commit();

    }
}
