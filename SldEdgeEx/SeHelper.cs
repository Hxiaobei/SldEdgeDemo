using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SeApp = SolidEdgeFramework.Application;

namespace SldEdgeEx
{
    public static class SeHelper
    {
        /// <summary>
        /// 设置SolidEdge程序执行状态
        /// </summary>
        /// <param name="DelayCompute">是否暂停计算过程</param>
        /// <param name="DisplayAlerts">是否禁用显示警告消息</param>
        /// <param name="Interactive">是否可以以交互方式使用引用的应用进程对象</param>
        /// <param name="ScreenUpdating">确定是启用还是禁用屏幕更新</param>
        /// <param name="Visible">是否显示程序</param>
        public static void SetAppStatus(this SeApp seApp, bool DelayCompute = false, bool DisplayAlerts = false, bool Interactive = false, bool ScreenUpdating = false, bool Visible = true) {
            //是否暂停计算过程
            seApp.DelayCompute = DelayCompute;
            //是否禁用显示警告消息
            seApp.DisplayAlerts = DisplayAlerts;
            //是否可以以交互方式使用引用的应用进程对象。
            seApp.Interactive = Interactive;
            //是否启用还是禁用屏幕更新
            seApp.ScreenUpdating = ScreenUpdating;
            //是否显示应用程序
            seApp.Visible = Visible;
        }

    }

}
