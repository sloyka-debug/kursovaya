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
using Microsoft.Win32;

namespace CURSED
{
    /// <summary>
    /// Логика взаимодействия для addfood.xaml
    /// </summary>
    public partial class addfood : Page
    {
        public addfood(string user)
        {
            InitializeComponent();
            ControlModule SQLControl = new ControlModule();
            CategorySelect.ItemsSource = SQLControl.Categ();
            usernamelabel.Content = user;
        }

        public addfood(int id, string user)
        {
            InitializeComponent();
            EditButt.Visibility = Visibility.Visible;
            AddButt.Visibility = Visibility.Hidden;
            ControlModule SQLControl = new ControlModule();
            CategorySelect.ItemsSource = SQLControl.Categ();
            FoodAdvanced food = SQLControl.Foodinf(id);
            addfoodimg.Source = new BitmapImage(new Uri(food.ImagePath));
            pathblock.Text = food.ImagePath;
           
            FoodnameBox.Text = food.Foodname;
            
            DescriptionBox.Text = food.Description;
            FormulaBox.Text = food.Formula;
            PriceBox.Text = food.Price;
            CategorySelect.Text = food.Category;
            foodlabel.Content = id;
            usernamelabel.Content = user;


        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string fullpath = System.IO.Path.GetDirectoryName(openFileDialog.FileName) + @"\" + System.IO.Path.GetFileName(openFileDialog.FileName);
                pathblock.Text = fullpath;
                Uri fileUri = new Uri(openFileDialog.FileName);
                addfoodimg.Source = new BitmapImage(fileUri);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ControlModule SQLControl = new ControlModule();
            if (!string.IsNullOrEmpty(FoodnameBox.Text) && !string.IsNullOrEmpty(FormulaBox.Text) && !string.IsNullOrEmpty(PriceBox.Text) && !string.IsNullOrEmpty(CategorySelect.Text))
            {
                SQLControl.AddFoodToBd(FoodnameBox.Text, DescriptionBox.Text, FormulaBox.Text, Convert.ToInt32(PriceBox.Text), CategorySelect.Text, Convert.ToString(usernamelabel.Content), pathblock.Text);
                NavigationService.Navigate(new supplierpage(Convert.ToString(usernamelabel.Content)));
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            ControlModule SQLControl = new ControlModule();
            SQLControl.UpdateFood(FoodnameBox.Text, DescriptionBox.Text, FormulaBox.Text, Convert.ToInt32(PriceBox.Text), CategorySelect.Text, Convert.ToInt32(foodlabel.Content), pathblock.Text);
            NavigationService.Navigate(new supplierpage(Convert.ToString(usernamelabel.Content)));
        }
    }
}
