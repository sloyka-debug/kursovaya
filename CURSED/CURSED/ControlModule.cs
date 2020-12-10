using System;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace CURSED
{

    class ControlModule
    {
        SqlConnection sqlConnection;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\CURSED\CURSED\FoodDatabase.mdf;Integrated Security=True";

        SqlDataReader sqlReader;
        SqlCommand command;

        public bool LoginPasswordCheck(string login, string password)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            sqlReader = null;
            command = new SqlCommand("select * from [User] where Login=@Login and Password=@Password", sqlConnection);
            command.Parameters.AddWithValue("Login", login);
            command.Parameters.AddWithValue("Password", password);
            sqlReader = command.ExecuteReader();
            
            if (sqlReader.Read())
            {
                sqlConnection.Close();
                return true;
            }
            else
            {

                sqlConnection.Close();
                return false;
            }
        }

        public bool SupLoginPasswordCheck(string login, string password)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            sqlReader = null;
            command = new SqlCommand("select * from [Supplier] where Login=@Login and Password=@Password", sqlConnection);
            command.Parameters.AddWithValue("Login", login);
            command.Parameters.AddWithValue("Password", password);
            sqlReader = command.ExecuteReader();

            if (sqlReader.Read())
            {
                sqlConnection.Close();
                return true;
            }
            else
            {

                sqlConnection.Close();
                return false;
            }
        }

        public bool UniqLogin(string login)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            sqlReader = null;
            command = new SqlCommand("select Login from [User] where Login=@Login", sqlConnection);
            command.Parameters.AddWithValue("Login", login);
            sqlReader = command.ExecuteReader();

            if (sqlReader.Read())
            {
                sqlConnection.Close();
                return false;
            }
            else
            {
                sqlConnection.Close();
                return true;
            }
        }

        public bool UniqEmail(string email)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            sqlReader = null;
            command = new SqlCommand("select Email from [User] where Email=@Email", sqlConnection);
            command.Parameters.AddWithValue("Email", email);
            sqlReader = command.ExecuteReader();

            if (sqlReader.Read())
            {
                sqlConnection.Close();
                return false;
            }
            else
            {
                sqlConnection.Close();
                return true;
            }
        }

        public void Registration(string login, string password, string email)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO [User] (Login, Password, Email) Values (@Login, @Password, @Email)", sqlConnection);
            command.Parameters.AddWithValue("Login", login);
            command.Parameters.AddWithValue("Password", password);
            command.Parameters.AddWithValue("Email", email);
            

            command.ExecuteNonQuery();
        }

        public void AdvancedRegistration(string login, string password, string email)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO [Supplier] (Login, Password, Email) Values (@Login, @Password, @Email)", sqlConnection);
            command.Parameters.AddWithValue("Login", login);
            command.Parameters.AddWithValue("Password", password);
            command.Parameters.AddWithValue("Email", email);


            command.ExecuteNonQuery();
        }

        public void AddFoodToBd(string foodname, string description, string ingridients, int price, string category, string supplier, string image)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO [Stuff] (Foodname, Description, Ingridients, Price, Category, Supplier, Image) Values (@Foodname, @Description, @Ingridients, @Price, @Category, @Supplier, @Image)", sqlConnection);
            command.Parameters.AddWithValue("Foodname", foodname);
            command.Parameters.AddWithValue("Description", description);
            command.Parameters.AddWithValue("Ingridients", ingridients);
            command.Parameters.AddWithValue("Price", price);
            command.Parameters.AddWithValue("Category", category);
            command.Parameters.AddWithValue("Supplier", supplier);
            command.Parameters.AddWithValue("Image", image);


            command.ExecuteNonQuery();
        }



        public ObservableCollection<string> Categ() 
        {
            ObservableCollection<string> Categories = new ObservableCollection<string>();
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            command = new SqlCommand("select * from [Category] ", sqlConnection);
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                Categories.Add(Convert.ToString(sqlReader["CatName"]));
            }

            return Categories;
        }

        public ObservableCollection<Food> Foodlist(string categ)
        {
            ObservableCollection<Food> foods = new ObservableCollection<Food>();
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            command = new SqlCommand("select * from [Stuff] where Category=@category", sqlConnection);
            command.Parameters.AddWithValue("category", categ);
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                foods.Add(new Food { Foodname=Convert.ToString(sqlReader["Foodname"]) , ImagePath= Convert.ToString(sqlReader["Image"]), ID=Convert.ToInt32(sqlReader["ID"]), Price= Convert.ToString(sqlReader["Price"]), Supplier= Convert.ToString(sqlReader["Supplier"]) });
            }

            return foods;
        }

        public FoodAdvanced Foodinf(int id) 
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            command = new SqlCommand("select * from [Stuff] where Id=@ID", sqlConnection);
            command.Parameters.AddWithValue("ID", id);
            sqlReader = command.ExecuteReader();

            sqlReader.Read();
            FoodAdvanced food = new FoodAdvanced();
            food.ID = Convert.ToInt32(sqlReader["Id"]);
            food.Foodname = Convert.ToString(sqlReader["Foodname"]);
            food.Price = Convert.ToString(sqlReader["Price"]);
            food.Supplier = Convert.ToString(sqlReader["Supplier"]);
            food.ImagePath = Convert.ToString(sqlReader["Image"]);
            food.Description = Convert.ToString(sqlReader["Description"]);
            food.Formula= Convert.ToString(sqlReader["Ingridients"]);
            food.Category = Convert.ToString(sqlReader["Category"]);

            return food;
        }

        public ObservableCollection<Food> SupFoodlist(string user)
        {
            ObservableCollection<Food> foods = new ObservableCollection<Food>();
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            command = new SqlCommand("select * from [Stuff] where Supplier=@supplier", sqlConnection);
            command.Parameters.AddWithValue("supplier", user);
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                foods.Add(new Food { Foodname = Convert.ToString(sqlReader["Foodname"]), ImagePath = Convert.ToString(sqlReader["Image"]), ID = Convert.ToInt32(sqlReader["ID"]), Price = Convert.ToString(sqlReader["Price"]) });
            }

            return foods;
        }

        public void UpdateFood(string foodname, string description, string ingridients, int price, string category, int id, string image) 
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            
            command = new SqlCommand("Update [Stuff] set Foodname=@Foodname, Description=@Description, Ingridients=@Ingridients, Price=@Price, Category=@Category, Image=@Image where Id=@ID", sqlConnection);
            command.Parameters.AddWithValue("Foodname", foodname);
            command.Parameters.AddWithValue("Description", description);
            command.Parameters.AddWithValue("Ingridients", ingridients);
            command.Parameters.AddWithValue("Price", price);
            command.Parameters.AddWithValue("Category", category);
            command.Parameters.AddWithValue("Id", id);
            command.Parameters.AddWithValue("Image", image);
            command.ExecuteNonQuery();
            

        }

        public void AddtoCart(int stuff, string user) 
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            command = new SqlCommand("select * from [Cart] where Stuff=@Stuff and [Cart].[User]=@User", sqlConnection);
            command.Parameters.AddWithValue("Stuff", stuff);
            command.Parameters.AddWithValue("User", user);
            sqlReader = command.ExecuteReader();

            if (sqlReader.Read())
            {
                int amount = Convert.ToInt32( sqlReader["Amount"]) + 1;
                int id = Convert.ToInt32(sqlReader["id"]);
                sqlConnection.Close();
                command = new SqlCommand("Update [Cart] Set Amount=@Amount  where Id=@Id", sqlConnection);
                command.Parameters.AddWithValue("Amount", amount);
                command.Parameters.AddWithValue("Id", id);
                sqlConnection.Open();
                command.ExecuteNonQuery();

            }
            else
            {
                sqlConnection.Close();
                command = new SqlCommand("INSERT INTO [Cart] (Stuff, Amount, [Cart].[User]) Values (@Stuff, @Amount, @User)", sqlConnection);
                command.Parameters.AddWithValue("Stuff", stuff);
                command.Parameters.AddWithValue("Amount", 1);
                command.Parameters.AddWithValue("User", user);
                sqlConnection.Open();
                command.ExecuteNonQuery();

            }

            

        }

        public ObservableCollection<CartFood> CartFoodlist(string user)
        {
            ObservableCollection<CartFood> foods = new ObservableCollection<CartFood>();
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            command = new SqlCommand("select * from [Cart] inner join [Stuff] on [Cart].[Stuff] = [Stuff].[Id] where [Cart].[User]=@User", sqlConnection);
            command.Parameters.AddWithValue("User", user);
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                foods.Add(new CartFood { Foodname = Convert.ToString(sqlReader["Foodname"]), ImagePath = Convert.ToString(sqlReader["Image"]), ID = Convert.ToInt32(sqlReader["Id"]), Price = Convert.ToInt32(sqlReader["Price"])* Convert.ToInt32(sqlReader["Amount"]),Stuff= Convert.ToInt32(sqlReader["Stuff"]), Amount=Convert.ToInt32(sqlReader["Amount"]) });
            }

            return foods;
        }

        public void DeleteFood(int id) 
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            command = new SqlCommand("delete from [Cart] where Id=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", id);

            command.ExecuteNonQuery();
        }

        public void AddOrder(string user, string address, DateTime date) 
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO [Order] (Customer, Address, Date) Values (@Customer, @Address, @Date)", sqlConnection);
            command.Parameters.AddWithValue("Customer", user);
            command.Parameters.AddWithValue("Address", address);
            command.Parameters.AddWithValue("Date", date);
            command.ExecuteNonQuery();
            sqlConnection.Close();

            sqlConnection.Open();
            command = new SqlCommand("select Id From [Order] where Customer=@Customer and Address=@Address and Date=@Date ", sqlConnection);
            command.Parameters.AddWithValue("Customer", user);
            command.Parameters.AddWithValue("Address", address);
            command.Parameters.AddWithValue("Date", date);
            sqlReader = command.ExecuteReader();
            sqlReader.Read();            
            this.OrderStuff(user, Convert.ToInt32(sqlReader["Id"]));

        }

        public void OrderStuff(string user, int order) 
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Close();

            ObservableCollection<CartFood> foods = this.CartFoodlist(user);
            sqlConnection.Close();
            foreach (CartFood food in foods)
            {
                sqlConnection.Open();
                command = new SqlCommand("INSERT INTO [OrderStuff] ([OrderStuff].[Order], [OrderStuff].[Stuff], [OrderStuff].[Amount]) Values (@Order, @Stuff, @Amount)", sqlConnection);
                command.Parameters.AddWithValue("Order", order);
                command.Parameters.AddWithValue("Stuff", Convert.ToInt32( food.Stuff));
                command.Parameters.AddWithValue("Amount", Convert.ToInt32(food.Amount));
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }

            
            sqlConnection.Open();
            command = new SqlCommand("delete from [Cart] where User=@User", sqlConnection);
            command.Parameters.AddWithValue("User", user);
            command.ExecuteNonQuery();

        }


        

    }


}
