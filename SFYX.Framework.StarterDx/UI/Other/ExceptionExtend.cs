using Hades.Framework.BaseUI;
using Hades.Framework.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFYX.Framework.Starter
{
    internal static class ExceptionExtend
    {

        public static void ShowException(this Exception ex, bool showDialog = true)
        {
            StringBuilder sb = new StringBuilder();
            if (ex is AggregateException)
            {

                foreach (var e in (ex as AggregateException).InnerExceptions)
                {
                    sb.Append(e.InnerException != null ? e.InnerException.Message : e.Message);
                    sb.Append("\r\n");
                }
            }
            else if (ex is TimeoutException)
            {
                sb.Append(ex.Message);
            }
            else if (ex is System.ServiceModel.EndpointNotFoundException)
            {
                sb.Append(ex.InnerException.Message);
            }
            else
            {
                sb.Append(ex.Message);
            };
            LogTextHelper.Error(ex);
            if (showDialog)
            {
                MessageDxUtil.ShowError(sb.ToString());
            }
        }

        public static void ShowException(this Exception ex, IWin32Window owner, bool showDialog = true)
        {
            StringBuilder sb = new StringBuilder();
            if (ex is AggregateException)
            {

                foreach (var e in (ex as AggregateException).InnerExceptions)
                {
                    sb.Append(e.InnerException != null ? e.InnerException.Message : e.Message);
                    sb.Append("\r\n");
                }
            }
            else if (ex is TimeoutException)
            {
                sb.Append(ex.Message);
            }
            else if (ex is System.ServiceModel.EndpointNotFoundException)
            {
                sb.Append(ex.InnerException.Message);
            }
            else
            {
                sb.Append(ex.Message);
            };
            LogTextHelper.Error(ex);
            if (showDialog)
            {
                MessageDxUtil.ShowError(owner, sb.ToString());
            }
        }
    }
}
