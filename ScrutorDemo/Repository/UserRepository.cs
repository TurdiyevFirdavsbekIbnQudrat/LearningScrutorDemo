
namespace ScrutorDemo.Repository
{
    public class UserRepository : IGeneral<User>
    {
        private readonly ScrutorDb _database;
        public UserRepository(ScrutorDb database)
        {
            _database = database;
        }
        public bool Create(User value)
        {
            try
            {
                _database.Users.Add(value);
                _database.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _database.Users.ToList();
        }
    }
}
