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
using System.Collections.ObjectModel;

namespace CURSED
{
    /// <summary>
    /// Логика взаимодействия для foodlist.xaml
    /// </summary>
    public partial class foodlist : Page
    {
        
        public foodlist(string catego,string user)
        {
            InitializeComponent();

            ControlModule SQLContol = new ControlModule();

            userlable.Content = user;
            FoodList.ItemsSource = SQLContol.Foodlist(catego);
        }

        private void FoodList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Food idselect = (Food)FoodList.SelectedItem;
            NavigationService.Navigate(new foodinfo(idselect.ID, Convert.ToString(userlable.Content)));
        }

        private void AddToCartButton(object sender, RoutedEventArgs e)
        {
            ControlModule SQLContol = new ControlModule();
            Food idselect = (Food)FoodList.SelectedItem;
            SQLContol.AddtoCart(idselect.ID,Convert.ToString( userlable.Content));
        }
    }
}
