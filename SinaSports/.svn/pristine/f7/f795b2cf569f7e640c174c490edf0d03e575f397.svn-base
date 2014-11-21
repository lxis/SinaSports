using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PhoneApp80
{
    public partial class Page2 : PhoneApplicationPage
    {
        public Page2()
        {
            InitializeComponent();


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MediaElement me = new MediaElement();
            ContentPanel.Children.Clear();
            ContentPanel.Children.Add(me);
            string url = "http://v.iask.com/v_play_ipad.php?vid=128848769";
            if (!string.IsNullOrEmpty(TempData.Url))
                url = TempData.Url;
            me.Source = new Uri(url, UriKind.RelativeOrAbsolute);
            me.Play();
        }
    }
}