// User Class
namespace BankApp
{
    // User class represents individual users in the banking system
    internal class User
    {
        // Properties with private setters to enforce encapsulation and restrict direct modification from outside the class
        public string Name { get; private set; } // User's name
        public string Email { get; private set; } // User's email address
        public string Password { get; private set; } // User's password

        // Constructor to initialise User object with provided data
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
