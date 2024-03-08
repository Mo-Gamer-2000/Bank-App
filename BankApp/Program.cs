using System.Text.RegularExpressions;
namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, User> users = new Dictionary<string, User>();

            // Admin User
            User admin = new User { Name = "Moeez", Email = "Moeez@gmail.com", Password = "224466" };
            users.Add(admin.Name, admin);

            Console.WriteLine("**- WELCOME TO MO'S BANK -**");

            while (true)
            {
                Console.WriteLine("""
            **- MAIN MENU -**
            Select one of these options:
            1. Sign In
            2. Sign Up
            q. Quit
            """);

                Console.Write("Insert option: ");
                string? userInput = Console.ReadLine()?.ToLower();

                if (userInput == "1")
                {
                    Console.WriteLine("""
                **- SIGN IN -**
                Please, enter your name and password:
                """);

                    string? signInName = null;
                    string? signInPassword = null;

                    var validateSignInNameCondition = (string.IsNullOrEmpty(signInName) || signInName.Length < 3 || !signInName.All(char.IsLetter));

                    while (validateSignInNameCondition)
                    {
                        Console.WriteLine("Name must be at least 3 characters long and contain only letters.");
                        Console.Write("Name: ");
                        signInName = Console.ReadLine();

                        validateSignInNameCondition = string.IsNullOrEmpty(signInName) || signInName.Length < 3 || !signInName.All(char.IsLetter);
                    }

                    var validateSignInPasswordCondition = (string.IsNullOrEmpty(signInPassword) || signInPassword.Length < 6 || !Regex.IsMatch(signInPassword, @"^[0-9]+$"));

                    while (validateSignInPasswordCondition)
                    {
                        Console.WriteLine("Password must be at least 6 characters long and contain only integers.");
                        Console.Write("Password: ");
                        signInPassword = Console.ReadLine();

                        validateSignInPasswordCondition = string.IsNullOrEmpty(signInPassword) || signInPassword.Length < 6 || !Regex.IsMatch(signInPassword, @"^[0-9]+$");
                    }

                    if (users.TryGetValue(signInName, out User? loggedInUser) && loggedInUser?.Password == signInPassword)
                    {
                        Console.WriteLine($"Welcome back, {loggedInUser.Name}!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password. Please try again.");

                    }
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("""
                * *- SIGN UP -**
                Please, enter your name, email and password:
                """);

                    string? userName = null;
                    string? userEmail = null;
                    string? userPassword = null;

                    var validateNameCondition = (string.IsNullOrEmpty(userName) || userName.Length < 3 || !userName.All(char.IsLetter));

                    while (validateNameCondition)
                    {
                        Console.WriteLine("Name must be at least 3 characters long and contain only letters.");
                        Console.Write("Name: ");
                        userName = Console.ReadLine();

                        validateNameCondition = string.IsNullOrEmpty(userName) || userName.Length < 3 || !userName.All(char.IsLetter);
                    }

                    var validateEmailCondition = (string.IsNullOrEmpty(userEmail) || !IsValidEmail(userEmail));
                    while (validateEmailCondition)
                    {
                        Console.WriteLine("Please enter a valid email address.");
                        Console.Write("Email: ");
                        userEmail = Console.ReadLine();

                        validateEmailCondition = string.IsNullOrEmpty(userEmail) || !IsValidEmail(userEmail);
                    }

                    var validatePasswordCondition = (string.IsNullOrEmpty(userPassword) || userPassword.Length < 6 || !Regex.IsMatch(userPassword, @"^[0-9]+$"));

                    while (validatePasswordCondition)
                    {
                        Console.WriteLine("Password must be at least 6 characters long and contain only integers.");
                        Console.Write("Password: ");
                        userPassword = Console.ReadLine();

                        validatePasswordCondition = string.IsNullOrEmpty(userPassword) || userPassword.Length < 6 || !Regex.IsMatch(userPassword, @"^[0-9]+$");
                    }

                    User newUser = new User { Name = userName, Email = userEmail, Password = userPassword };
                    users.Add(userName, newUser);

                    Console.WriteLine("You have successfully signed up with Mo's Bank!");

                    bool IsValidEmail(string email)
                    {
                        try
                        {
                            var addr = new System.Net.Mail.MailAddress(email);
                            return addr.Address == email && (email.Contains("@gmail.com") || email.Contains("@hotmail.com") || email.Contains("@yahoo.com") || email.Contains("@outlook.com"));
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
                else if (userInput == "q")
                {
                    Console.WriteLine("""
                * *- QUIT -**
                Thank you for using Mo's banking!
                """);
                    break;
                }
                else
                {
                    Console.WriteLine("Oops! Something went wrong. Please, try again!");
                }
            }
        }
    }
}