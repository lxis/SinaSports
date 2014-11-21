using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SM.Media.MediaPlayer;

namespace PhoneApp80
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Microsoft.PlayerFramework.MediaPlayer player = new Microsoft.PlayerFramework.MediaPlayer();
            string url = "http://wtv.v.iask.com/player/ovs1_vod_rid_2014100029_br_3_pn_weitv_tn_0_sig_md5.m3u8";
            if (!string.IsNullOrEmpty(TempData.Url))
                url = TempData.Url;
            player.Source = new Uri(url, UriKind.RelativeOrAbsolute);
            StreamingMediaPlugin plugins = new StreamingMediaPlugin();
            player.Plugins.Add(plugins);
            ContentPanel.Children.Clear();
            ContentPanel.Children.Add(player);
        }
    }
}