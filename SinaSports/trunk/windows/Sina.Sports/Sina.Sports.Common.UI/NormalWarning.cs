using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.UI.Popups;

namespace Sina.Sports.Common.UI
{
    public class NormalWarning
    {
        static NromalWarningInternal nromalWarningInternal = new NromalWarningInternal();

        /// <summary>
        /// 需确认提醒，确认取消两个按钮
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public async static Task<bool> ShowConfirm(string message, string caption = "")
        {
            return await nromalWarningInternal.Show(message, caption);
        }

        /// <summary>
        /// 可忽略提醒，没返回值
        /// </summary>
        /// <param name="message"></param>
        public static void ShowNegligible(string message)
        {
            nromalWarningInternal.ShowNegligible(message);
        }
    }

    class NromalWarningInternal
    {
        public async Task<bool> Show(string message, string caption = "")//刚刚改写，没有测试
        {
            MessageDialog dialog = new MessageDialog(message, caption);
            bool? result = null;
            dialog.Commands.Add(new UICommand("OK",new UICommandInvokedHandler((cmd) => result = true)));
            dialog.Commands.Add(new UICommand("Cancel",new UICommandInvokedHandler((cmd) => result = true)));
            await dialog.ShowAsync();
            return result.Value;
            //MessageBoxResult result = MessageBox.Show(message, caption, MessageBoxButton.OKCancel);
            //return result == MessageBoxResult.OK;
        }
        public void ShowNegligible(string message)
        {
            //TrayStayHelper.ShowMessage(message, 2);
        }
    }
}
