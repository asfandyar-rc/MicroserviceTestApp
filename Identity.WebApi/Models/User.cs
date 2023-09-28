namespace Identity.WebApi.Models
{
    public class User
    {
        public string   UserName { get; set; }
        public string   Password { get; set; }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public List<User> AllUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User("asfand@gmail.com", "test123"));
            users.Add(new User("royalcyber@gmail.com", "rc123"));
            return users;
        }
    }
}
