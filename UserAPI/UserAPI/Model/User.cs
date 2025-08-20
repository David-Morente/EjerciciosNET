namespace UserAPI.Model
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        public User (string name, string email, string password, DateTime dateOfBirth)
        {
            Name = name;
            Email = email;
            this.Password = password;
            DateOfBirth = dateOfBirth;
        }
    }
}
