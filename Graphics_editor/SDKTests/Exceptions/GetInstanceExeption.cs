using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKTests.Exceptions
{

    internal class GetInstanceExeption : Exception
    {
        public GetInstanceExeption(string message)
            : base(message) { }
    }
}
