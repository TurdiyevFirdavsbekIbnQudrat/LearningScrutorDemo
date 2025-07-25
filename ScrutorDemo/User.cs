using ScrutorDemo.Validators;

namespace ScrutorDemo
{
    public class User
    {
        public int Id { get; set; }
        [StartsWithValidate]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
