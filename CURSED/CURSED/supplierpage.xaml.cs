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
    /// Логика взаимодействия для supplierpage.xaml
    /// </summary>
    public partial class supplierpage : Page
    {
        public supplierpage(string user)
        {
            InitializeComponent();
            usernamelabel.Content = user;

            ControlModule SQLContol = new ControlModule();


            FoodList.ItemsSource = SQLContol.SupFoodlist(user);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new addfood(Convert.ToString(usernamelabel.Content)));
        }

        private void FoodList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Food idselect = (Food)FoodList.SelectedItem;
            NavigationService.Navigate(new addfood(idselect.ID, Convert.ToString(usernamelabel.Content)));
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/startpage.xaml", UriKind.Relative));
        }
    }
}
