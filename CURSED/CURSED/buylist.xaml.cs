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
    /// Логика взаимодействия для buylist.xaml
    /// </summary>
    public partial class buylist : Page
    {
        public buylist(string user)
        {
            InitializeComponent();
            ControlModule SQLContol = new ControlModule();

            
            FoodList.ItemsSource = SQLContol.CartFoodlist(user);
            userlable.Content = user;
        }

        private void BuyButton(object sender, RoutedEventArgs e)
        {

        }

        private void FoodToDelete(object sender, SelectionChangedEventArgs e)
        {
            ControlModule SQLContol = new ControlModule();
            CartFood idselect = (CartFood)FoodList.SelectedItem;
            if (!(idselect is null)) 
            {
                SQLContol.DeleteFood(idselect.ID); 
            }
            

            FoodList.ItemsSource = SQLContol.CartFoodlist(Convert.ToString(userlable.Content));
        }

        private void toOrderClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Orderpage(Convert.ToString(userlable.Content)));
        }
    }
}
