using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using SolidEdgeFramework;



namespace SldEdgeEx {
    public class SeUtils {
        static Application _seApp;
        public static Application Se => _seApp ?? GetSeApp();
        static Application GetSeApp() {
            if(_seApp == null) {
                try {
                    _seApp = (Application)Marshal.GetActiveObject("SolidEdge.Application");
                } catch(COMException) {
                    try {
                        _seApp = (Application)Marshal.GetActiveObject("SolidEge.Application.28");//2020
                    } catch(COMException) {
                        //MessageBox.Show("Could not connect to SolidEge.", "SolidEge", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        _seApp = null;
                    }
                }
            }

            return _seApp;
        }
        public static void SetSeApp(Application seApp) => _seApp = seApp;

    }
}
