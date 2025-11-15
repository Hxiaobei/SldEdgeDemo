using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SolidEdgeFramework;

namespace SldEdgeEx.NetCore {
    public class SeUtils {
        public static Application GetSldApp() => (Application)MarshalForCore.GetActiveObject("SolidEdge.Application");

    }
}
