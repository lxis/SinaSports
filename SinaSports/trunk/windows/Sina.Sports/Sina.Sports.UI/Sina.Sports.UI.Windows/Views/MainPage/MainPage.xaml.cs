﻿using Newtonsoft.Json;
using Sina.Sports.Common.UI.Images;
using Sina.Sports.Server.Common.RequestModel;
using Sina.Sports.UI.Views.MainPage;
using Sina.Sports.UI.WorkerServices.Initializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace Sina.Sports.UI
{
    /// <summary>
    /// 可独立使用或用于导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            new ApplicationInitializer().Init();
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlankPage));

            Image image1 = null;

            await ImageManager.Loader.Load(image1, new RestRequest { Url = "www.baidu.com" });
        }
    }
}
