class User
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<User> users = new List<User>();

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

                while (string.IsNullOrEmpty(signInName))
                {
                    Console.Write("Name: ");
                    signInName = Console.ReadLine();
                }

                while (string.IsNullOrEmpty(signInPassword))
                {
                    Console.Write("Password: ");
                    signInPassword = Console.ReadLine();
                }

                User loggedInUser = users.Find(user => user.Name == signInName && user.Password == signInPassword);

                if (loggedInUser != null)
                {
                    Console.WriteLine($"Welcome back, {loggedInUser.Name}!");
                }
                else
                {
                    Console.WriteLine("Invalid username and password. Please try again.");
                }
            }
            else if (userInput == "2")
            {
                Console.WriteLine("""
                **- SIGN UP -**
                Please, enter your name, email and password:
                """);

                string? userName = null;
                string? userEmail = null;
                string? userPassword = null;

                // Validate name
                while (string.IsNullOrEmpty(userName) || userName.Length < 3 || !userName.All(char.IsLetter))
                {
                    Console.WriteLine("Name must be at least 3 characters long and contain only letters.");
                    Console.Write("Name: ");
                    userName = Console.ReadLine();
                }

                // Validate email
                while (string.IsNullOrEmpty(userEmail) || !IsValidEmail(userEmail))
                {
                    Console.WriteLine("Please enter a valid email address.");
                    Console.Write("Email: ");
                    userEmail = Console.ReadLine();
                }

                // Validate password
                while (string.IsNullOrEmpty(userPassword) || userPassword.Length < 6)
                {
                    Console.WriteLine("Password must be at least 6 characters long.");
                    Console.Write("Password: ");
                    userPassword = Console.ReadLine();
                }

                User newUser = new User { Name = userName, Email = userEmail, Password = userPassword };
                users.Add(newUser);

                Console.WriteLine("You have successfully signed up with Mo's Bank!");

                // Email validation method
                bool IsValidEmail(string email)
                {
                    try
                    {
                        var addr = new System.Net.Mail.MailAddress(email);
                        return addr.Address == email && (email.Contains("@gmail.com") || email.Contains("@yahoo.com") || email.Contains("@outlook.com"));
                    } catch
                    {
                        return false;
                    }
                }
            }
            else if (userInput == "q")
            {
                Console.WriteLine("""
                **- QUIT -**
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

