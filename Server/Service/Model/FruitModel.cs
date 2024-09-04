namespace Service
{
    public class Fruit
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Id { get; set; }
    }

    public class FruitService
    {
        private readonly List<Fruit> _fruits = new();

        public IEnumerable<Fruit> GetAll() => _fruits;

        public Fruit GetById(int id) => _fruits.FirstOrDefault(f => f.Id == id);

        public void Add(Fruit fruit) => _fruits.Add(fruit);

        public void Update(Fruit fruit)
        {
            var existingFruit = GetById(fruit.Id);
            if (existingFruit != null)
            {
                existingFruit.Name = fruit.Name;
                existingFruit.Price = fruit.Price;
            }
        }

        public void Delete(int id) => _fruits.RemoveAll(f => f.Id == id);
    }
}