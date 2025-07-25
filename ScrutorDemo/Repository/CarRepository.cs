
using Enyim.Caching;

namespace ScrutorDemo.Repository
{
    public class CarRepository : IGeneral<Car>
    {
        private readonly IMemcachedClient _memcacheclient;
        private readonly ScrutorDb _database;
        public CarRepository(ScrutorDb database, IMemcachedClient memcacheclient)
        {
            _database = database;
            _memcacheclient = memcacheclient;
        }

        public string CleanCache()
        {
            throw new NotImplementedException();
        }

        public bool Create(Car value)
        {
            try
            {
                _database.Cars.Add(value);
                _database.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public IEnumerable<Car> GetAll()
        {
            var allCars = _database.Cars.ToList();
            var isSaved = _memcacheclient.Set("AllCars", allCars, 2500);
             Console.WriteLine(isSaved);
            return allCars;
        }
        public IEnumerable<Car> IfExistGetAll()
        {
           return _memcacheclient.Get<IEnumerable<Car>>("AllCars");
           
        }
    }
}
