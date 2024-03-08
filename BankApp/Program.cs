using System.Text.RegularExpressions;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dictionary to store user data with username as key
            Dictionary<string, User> users = new Dictionary<string, User>();

            // Admin User - pre-added user (MySelf)
            User admin = new User("Moeez", "Moeez@gmail.com", "224466");
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

                // Option 1: Sign In
                if (userInput == "1")
                {
                    Console.WriteLine("""
                **- SIGN IN -**
                Please, enter your name and password:
                """);

                    string? signInName = null; // Initialise signInName variable
                    string? signInPassword = null; // Initialise signInPassword variable

                    // Validate Sign In Name
                    var validateSignInNameCondition = (string.IsNullOrEmpty(signInName) || signInName.Length < 3 || !signInName.All(char.IsLetter));
                    while (validateSignInNameCondition)
                    {
                        // Prompt user for name
                        Console.WriteLine("Name must be at least 3 characters long and contain only letters.");
                        Console.Write("Name: ");
                        signInName = Console.ReadLine(); // Read user input

                        // Update validation condition
                        validateSignInNameCondition = string.IsNullOrEmpty(signInName) || signInName.Length < 3 || !signInName.All(char.IsLetter);
                    }

                    // Validate Sign In Password
                    var validateSignInPasswordCondition = (string.IsNullOrEmpty(signInPassword) || signInPassword.Length < 6 || !Regex.IsMatch(signInPassword, @"^[0-9]+$"));
                    while (validateSignInPasswordCondition)
                    {
                        // Prompt user for password
                        Console.WriteLine("Password must be at least 6 characters long and contain only integers.");
                        Console.Write("Password: ");
                        signInPassword = Console.ReadLine(); // Read user input

                        // Update validation condition
                        validateSignInPasswordCondition = string.IsNullOrEmpty(signInPassword) || signInPassword.Length < 6 || !Regex.IsMatch(signInPassword, @"^[0-9]+$");
                    }

                    // Check if user exists and password matches
                    if (users.TryGetValue(signInName, out User? loggedInUser) && loggedInUser?.Password == signInPassword)
                    {
                        Console.WriteLine($"Welcome back, {loggedInUser.Name}!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password. Please try again.");
                    }
                }
                // Option 2: Sign Up
                else if (userInput == "2")
                {
                    Console.WriteLine("""
                * *- SIGN UP -**
                Please, enter your name, email and password:
                """);

                    string? userName = null; // Initialise userName variable
                    string? userEmail = null; // Initialise userEmail variable
                    string? userPassword = null; // Initialise userPassword variable

                    // Validate Name
                    var validateNameCondition = (string.IsNullOrEmpty(userName) || userName.Length < 3 || !userName.All(char.IsLetter));
                    while (validateNameCondition)
                    {
                        // Prompt user for name
                        Console.WriteLine("Name must be at least 3 characters long and contain only letters.");
                        Console.Write("Name: ");
                        userName = Console.ReadLine(); // Read user input

                        // Update validation condition
                        validateNameCondition = string.IsNullOrEmpty(userName) || userName.Length < 3 || !userName.All(char.IsLetter);
                    }

                    // Validate Email
                    var validateEmailCondition = (string.IsNullOrEmpty(userEmail) || !IsValidEmail(userEmail));
                    while (validateEmailCondition)
                    {
                        // Prompt user for email
                        Console.WriteLine("Please enter a valid email address.");
                        Console.Write("Email: ");
                        userEmail = Console.ReadLine(); // Read user input

                        // Update validation condition
                        validateEmailCondition = string.IsNullOrEmpty(userEmail) || !IsValidEmail(userEmail);
                    }

                    // Validate Password
                    var validatePasswordCondition = (string.IsNullOrEmpty(userPassword) || userPassword.Length < 6 || !Regex.IsMatch(userPassword, @"^[0-9]+$"));
                    while (validatePasswordCondition)
                    {
                        // Prompt user for password
                        Console.WriteLine("Password must be at least 6 characters long and contain only integers.");
                        Console.Write("Password: ");
                        userPassword = Console.ReadLine(); // Read user input

                        // Update validation condition
                        validatePasswordCondition = string.IsNullOrEmpty(userPassword) || userPassword.Length < 6 || !Regex.IsMatch(userPassword, @"^[0-9]+$");
                    }

                    // Create new User object and add to dictionary
                    User newUser = new User(userName, userEmail, userPassword);
                    users.Add(userName, newUser);

                    // Confirmation message
                    Console.WriteLine("You have successfully signed up with Mo's Bank!");

                    // Method to validate email
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
                // Option q: Quit
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
