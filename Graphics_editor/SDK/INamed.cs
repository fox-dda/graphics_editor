using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK
{
    public interface INamed
    {
        /// <summary>
        /// Вернуть тип
        /// </summary>
        /// <returns></returns>
        string GetName();
    }
}
