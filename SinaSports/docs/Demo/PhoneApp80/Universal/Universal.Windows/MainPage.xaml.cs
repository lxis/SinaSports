using SM.Media.MediaPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace Universal
{
    /// <summary>
    /// 可独立使用或用于导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ShowStream();

        }

        private void ShowStream()
        {
            Microsoft.PlayerFramework.MediaPlayer player = new Microsoft.PlayerFramework.MediaPlayer();
            player.Source = new Uri("http://wtv.v.iask.com/player/ovs1_vod_rid_2014100029_br_3_pn_weitv_tn_0_sig_md5.m3u8", UriKind.RelativeOrAbsolute);
            StreamingMediaPlugin plugins = new StreamingMediaPlugin();
            player.Plugins.Add(plugins);
            grid.Children.Add(player);
        }
    }
}
