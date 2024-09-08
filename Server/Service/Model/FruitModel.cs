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

    // FruitService.cs
    namespace Service
    {
        public class FruitService
        {
            private readonly List<Fruit> _fruits = new();
            private int _nextId = 1;

            public IEnumerable<Fruit> GetAll() => _fruits;

            public Fruit? GetById(int id) => _fruits.FirstOrDefault(f => f.Id == id);

            public void Add(Fruit fruit)
            {
                fruit.Id = _nextId++;
                _fruits.Add(fruit);
            }

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
}