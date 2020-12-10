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
    /// Логика взаимодействия для foodinfo.xaml
    /// </summary>
    public partial class foodinfo : Page
    {
        public foodinfo(int id,string user)
        {
            
            InitializeComponent();
            ControlModule control = new ControlModule();
            FoodAdvanced food = control.Foodinf(id);
            foodpic.Source = new BitmapImage(new Uri(food.ImagePath));
            foodname.Content = food.Foodname;
            suplogin.Content = food.Supplier;
            descbox.Text = food.Description;
            formulabox.Text = food.Formula;


            userlable.Content = user;
            idlable.Content = id;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ControlModule SQLContol = new ControlModule();
            SQLContol.AddtoCart(Convert.ToInt32(idlable.Content), Convert.ToString(userlable.Content));
        }
    }
}
