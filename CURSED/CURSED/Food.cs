namespace CURSED
{
    public class Food 
    {
        public string Foodname { get; set; }
        public string Price { get; set; }

        public int ID { get; set; }
        public string Supplier { get; set; }
        public string ImagePath { get; set; }
    }

    public class FoodAdvanced: Food 
    {
        public string Description { get; set; }
        public string Formula { get; set; }
        public string Category { get; set; }
    }

    public class CartFood
    {
        public int ID { get; set; }
        public string Foodname { get; set; }
        public int Amount { get; set; }

        public int Price { get; set; }
        public string ImagePath { get; set; }
        public int Stuff { get; set; }

    }
}
