
namespace ScrutorDemo.Repository
{
    public class CarRepository : IGeneral<Car>
    {
        private readonly ScrutorDb _database;
        public CarRepository(ScrutorDb database)
        {
            _database = database;
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
            return _database.Cars.ToList();
        }
    }
}
