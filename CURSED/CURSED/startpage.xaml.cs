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
    public partial class startpage : Page
    {
        public startpage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ControlModule controlM = new ControlModule();
            if (controlM.LoginPasswordCheck(LoginTextBox.Text, PasswordTextBox.Text)) 
            { 
                NavigationService.Navigate(new foodpage(LoginTextBox.Text));
            }

            else if (controlM.SupLoginPasswordCheck(LoginTextBox.Text, PasswordTextBox.Text))
            {

                NavigationService.Navigate(new supplierpage(LoginTextBox.Text));
                
            }
            else 
            {
                errorlable.Visibility = Visibility.Visible;
            }

        }
    }
}
