
using Microsoft.Extensions.Caching.Memory;

namespace ScrutorDemo.Repository
{
    public class UserRepository : IGeneral<User>
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger _logger;
        private readonly ScrutorDb _database;
        public UserRepository(ScrutorDb database, ILogger<UserRepository> logger,IMemoryCache memoryCache)
        {
            _database = database;
            _logger = logger;
            _memoryCache = memoryCache;
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
            var users = _database.Users.ToList();
            bool isSaved = isSavedToMemory(users);
            if (isSaved) 
            {
                _logger.Log(LogLevel.Information, "User added to cache");
            }
            return users;
        }
        private bool isSavedToMemory(IEnumerable<User> users)
        {
            
                string key = "User";
                var cacheEntrPoints = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(5))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(10))
                    .RegisterPostEvictionCallback(EvictionCallback,_memoryCache)
                    .SetPriority(CacheItemPriority.Normal);

                var a = _memoryCache.Set(key, users, cacheEntrPoints);

            if (a != null)
            {
                return true;
            }
                else return false;
            

        }
        public IEnumerable<User> IfExistGetAll()
        {
            var DataFromMemorycache = _memoryCache.Get("User") as IEnumerable<User>;
            if(DataFromMemorycache == null)
            {
                return Enumerable.Empty<User>();
            }
            else
            {
                return DataFromMemorycache;
            }
        }

        public string CleanCache()
        {
           _memoryCache.Remove("User");
            
            return "Keshdan malumotlar o'chirildi";
        }

        private void EvictionCallback(object key, object value, EvictionReason reason,object state)
        {
            Console.WriteLine($"Keshdan o'chirildi: {key} - Sabab: {reason}");
        }
    }
}
