using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CURSED
{
    /// <summary>
    /// Логика взаимодействия для foodpage.xaml
    /// </summary>
    public partial class foodpage : Page
    {
        public foodpage(string user)
        {
            InitializeComponent();
            
            leftframe.Navigate(new foodlist("Супы", user));
            usernamelabel.Content = user;
        }

        private void soupclick(object sender, RoutedEventArgs e)
        {
            leftframe.Navigate(new foodlist("Супы", Convert.ToString( usernamelabel.Content)));
        }

        private void hotclick(object sender, RoutedEventArgs e)
        {
            leftframe.Navigate(new foodlist("Горячие Блюда", Convert.ToString(usernamelabel.Content)));
        }

        private void coldclick(object sender, RoutedEventArgs e)
        {
            leftframe.Navigate(new foodlist("Холодные Блюда", Convert.ToString(usernamelabel.Content)));
        }

        private void sweetclick(object sender, RoutedEventArgs e)
        {
            leftframe.Navigate(new foodlist("Десерты", Convert.ToString(usernamelabel.Content)));
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            leftframe.Navigate(new buylist(Convert.ToString(usernamelabel.Content)));
        }

        private void LogoutImage(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/startpage.xaml", UriKind.Relative));
        }
    }
}
