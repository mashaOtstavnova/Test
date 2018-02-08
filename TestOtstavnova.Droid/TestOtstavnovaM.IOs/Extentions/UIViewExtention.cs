using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace TestOtstavnovaM.IOs.Extentions
{
    public static class UIViewExtention
    {
        /// <summary>
        /// смещение по x
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static float GetEndViewWidth(this UIView view)
        {
            return (float)(view.Frame.Width + view.Frame.X);
        }
        /// <summary>
        /// смещение по y
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static float GetEndViewHeight(this UIView view)
        {
            return (float)(view.Frame.Height + view.Frame.Y);
        }
    }
}