namespace Service
{
    public class Fruit
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Id { get; set; }

        public Fruit(string name, int price, int id)
        {
            Name = name;
            Price = price;
            Id = id;
        }
    }
}