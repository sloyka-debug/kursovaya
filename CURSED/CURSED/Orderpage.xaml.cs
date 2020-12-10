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
    /// Логика взаимодействия для Orderpage.xaml
    /// </summary>
    public partial class Orderpage : Page
    {
        public Orderpage(string user)
        {
            InitializeComponent();
            userlabel.Content = user;
        }

        private void Ordernow(object sender, RoutedEventArgs e)
        {
            ControlModule SQLControl = new ControlModule();
            if (!string.IsNullOrEmpty(AddressTextBox.Text) && !string.IsNullOrEmpty(DataSelect.Text)) 
            {
                DateTime nowdate = DateTime.Now;
                switch (DataSelect.SelectedIndex)
                {
                    case 0:
                        nowdate = DateTime.Now;
                        break;
                    case 1:
                        nowdate = nowdate.AddDays(1);
                        break;
                    case 2:
                        nowdate = nowdate.AddDays(2);
                        break;
                    case 3:
                        nowdate = nowdate.AddDays(3);
                        break;
                    case 4:
                        nowdate = nowdate.AddDays(7);
                        break;

                    default:
                        break;
                }

                SQLControl.AddOrder(Convert.ToString(userlabel.Content),AddressTextBox.Text, nowdate);
                NavigationService.Navigate(new foodlist("Супы", Convert.ToString(userlabel.Content)));
            }
        }
    }
}
