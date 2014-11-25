using Sina.Sports.Common.InversionofControl;
using Sina.Sports.Common.UI.Controls.Warning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Sina.Sports.Common.UI
{
    public class TrayStayHelper
    {
        public static void ShowMessage(string message, int second = 2)
        {
            TrayStayHelperInternal heplerInternal = new TrayStayHelperInternal();
            heplerInternal.ShowMessage(message, second);
        }

        public static void CloseMessage()
        {
            TrayStayHelperInternal helperInternal = new TrayStayHelperInternal();
            helperInternal.CloseMessage();
        }

        public static async Task DoBusyWork(Func<Task> task, string text = null)
        {
            TrayStayHelperInternal heplerInternal = new TrayStayHelperInternal();
            await heplerInternal.DoBusyWork(task, text);
        }

        public static async Task<T> DoBusyWork<T>(Func<Task<T>> task, string text = null)
        {
            TrayStayHelperInternal heplerInternal = new TrayStayHelperInternal();
            return await heplerInternal.DoBusyWork<T>(task, text);
        }
    }


    class SystemTrayState
    {
        public bool ProgIndicatorIsVisible { get; set; }
        public bool ProgIndicatorIsIndeterminate { get; set; }
        public bool SystemTrayIsVisible { get; set; }
        public bool ProgressIndicatorNull { get; set; }
        public string ProgressIndicatorText { get; set; }
        public WeakReference<DependencyObject> Page { get; set; }
    }

    class TrayStayHelperInternal
    {
        public static SystemTrayState state;
        public static IList<Guid> currentThreads = new List<Guid>();

        private DependencyObject GetCurrentPage()
        {
            throw new NotImplementedException();
            //var currentPage = ((PhoneApplicationFrame)Application.Current.RootVisual).Content as DependencyObject;
            //if (currentPage == null)
            //    throw new ArgumentNullException("Current Page");
            //return currentPage;
        }

        /// <summary>
        /// 这个是用系统实现的
        /// </summary>
        /// <param name="message"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public async Task ShowMessageTrayStay(string message, int? second = null)
        {
            //Guid guid = Guid.NewGuid();
            //currentThreads.Add(guid);
            //SaveState();
            //ProgressIndicator tProgIndicator = new ProgressIndicator();
            //tProgIndicator.IsVisible = true;
            //tProgIndicator.Text = message;
            //SystemTray.SetProgressIndicator(GetCurrentPage(), tProgIndicator);
            //SystemTray.IsVisible = true;
            //if (second != null)
            //{
            //    await Task.Delay(new TimeSpan(0, 0, second.Value));
            //    ResumeState();
            //}
            //currentThreads.Remove(guid);
        }

        public void ShowMessage(string message, int second = 3)
        {
            Ioc<IToastMessage>.Create().ShowToastMessage(message, second);
        }

        public void CloseMessage()
        {
            Ioc<IToastMessage>.Create().CloseToastMessage();
        }

        public void CloseMessageTrayStay()
        {

            //SystemTray.ProgressIndicator.IsVisible = false;
            //SystemTray.ProgressIndicator.Text = string.Empty;
        }

        internal void ShowWaiting(string text = null)
        {
            //ProgressIndicator tProgIndicator = new ProgressIndicator();
            //tProgIndicator.IsVisible = true;
            //tProgIndicator.IsIndeterminate = true;
            //if (text != null)
            //    tProgIndicator.Text = text;
            //SystemTray.SetProgressIndicator(GetCurrentPage(), tProgIndicator);
            //SystemTray.IsVisible = true;
        }

        internal void StopWaiting()
        {
            //SystemTray.ProgressIndicator.IsIndeterminate = false;
            //SystemTray.ProgressIndicator.IsVisible = false;
        }

        public async Task DoBusyWorkTrayStay(Func<Task> task, string text = null)
        {
            Guid guid = Guid.NewGuid();
            currentThreads.Add(guid);
            SaveState();
            ShowWaiting(text);
            try
            {
                await task();
            }
            finally
            {
                ResumeState();//每一个完成都会回复状态，稍微有点简单粗暴
                currentThreads.Remove(guid);
            }
        }

        public async Task DoBusyWork(Func<Task> task, string text = null)
        {
            if (text == null)
                text = "加载中……";
            Ioc<IToastMessage>.Create().ShowToastMessage(text);
            try
            {
                await task();
            }
            finally
            {
                Ioc<IToastMessage>.Create().CloseToastMessage();
            }
        }

        public async Task<T> DoBusyWork<T>(Func<Task<T>> task, string text = null)
        {
            if (text == null)
                text = "加载中……";
            Ioc<IToastMessage>.Create().ShowToastMessage(text);
            try
            {
                var result = await task();
                return result;
            }
            finally
            {
                Ioc<IToastMessage>.Create().CloseToastMessage();
            }
        }


        /// <summary>
        /// 这个是用系统的实现的
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="task"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task<T> DoBusyWorkTrayStay<T>(Func<Task<T>> task, string text = null)
        {
            Guid guid = Guid.NewGuid();
            currentThreads.Add(guid);
            SaveState();
            ShowWaiting(text);
            try
            {
                var result = await task();
                return result;
            }
            finally
            {
                ResumeState();
                currentThreads.Remove(guid);
            }
        }

        internal void ResumeState()
        {
            //if (currentThreads.Count == 1)
            //{
            //    DependencyObject savedPage;
            //    if (state.Page.TryGetTarget(out savedPage))
            //    {
            //        SystemTray.SetIsVisible(savedPage, state.SystemTrayIsVisible);
            //        if (state.ProgressIndicatorNull)
            //        {
            //            SystemTray.SetProgressIndicator(savedPage, null);
            //        }
            //        else
            //        {
            //            ProgressIndicator tProgIndicator = new ProgressIndicator();
            //            tProgIndicator.IsIndeterminate = state.ProgIndicatorIsIndeterminate;
            //            tProgIndicator.IsVisible = state.ProgIndicatorIsVisible;
            //            tProgIndicator.Text = state.ProgressIndicatorText;
            //            SystemTray.SetProgressIndicator(savedPage, tProgIndicator);
            //        }
            //    }
            //    state = null;
            //}
        }

        internal void SaveState()
        {

            //if (TrayStayHelperInternal.state != null)
            //    return;
            //SystemTrayState state = new SystemTrayState();
            //var currentPage = GetCurrentPage();
            //state.Page = new WeakReference<DependencyObject>(currentPage);
            //state.ProgressIndicatorNull = SystemTray.GetProgressIndicator(currentPage) == null;
            //if (!state.ProgressIndicatorNull)
            //{
            //    state.ProgIndicatorIsIndeterminate = SystemTray.GetProgressIndicator(currentPage).IsIndeterminate;
            //    state.ProgIndicatorIsVisible = SystemTray.GetProgressIndicator(currentPage).IsVisible;
            //    state.ProgressIndicatorText = SystemTray.GetProgressIndicator(currentPage).Text;
            //}
            //state.SystemTrayIsVisible = SystemTray.GetIsVisible(currentPage);
            //TrayStayHelperInternal.state = state;
        }
    }
}
