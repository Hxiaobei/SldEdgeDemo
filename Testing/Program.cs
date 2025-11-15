
using SolidEdgeFrameworkSupport;

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Collections.Generic;

class Program
{

    [STAThread]
    static void Main(string[] args)
    {
        System.Windows.Forms.Application.Run(new ColorPalette_Winform.Form1());
        //SeExample.RunStart();
    }

}
