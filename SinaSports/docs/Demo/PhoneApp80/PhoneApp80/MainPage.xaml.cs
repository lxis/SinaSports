using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp80.Resources;
using SM.Media.MediaPlayer;

namespace PhoneApp80
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TempData.Url = address.Text.Trim();
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.RelativeOrAbsolute));        
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TempData.Url = address.Text.Trim();
            NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.RelativeOrAbsolute));
        }

    }
}