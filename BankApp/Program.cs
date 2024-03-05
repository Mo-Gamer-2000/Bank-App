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

                // Validate name - UPDATED this after the lesson, storing condition in a var
                var validateSignInNameCondition = (string.IsNullOrEmpty(signInName) || signInName.Length < 3 || !signInName.All(char.IsLetter));

                while (validateSignInNameCondition)
                {
                    Console.WriteLine("Name must be at least 3 characters long and contain only letters.");
                    Console.Write("Name: ");
                    signInName = Console.ReadLine();

                    // Update the condition after user input
                    validateSignInNameCondition = string.IsNullOrEmpty(signInName) || signInName.Length < 3 || !signInName.All(char.IsLetter);
                }

                // Validate password - UPDATED this after the lesson, storing condition in a var
                var validateSignInPasswordCondition = (string.IsNullOrEmpty(signInPassword) || signInPassword.Length < 6);

                while (validateSignInPasswordCondition)
                {
                    Console.WriteLine("Password must be at least 6 characters long.");
                    Console.Write("Password: ");
                    signInPassword = Console.ReadLine();

                    // Update the condition after user input
                    validateSignInPasswordCondition = string.IsNullOrEmpty(signInPassword) || signInPassword.Length < 6;
                }

                User loggedInUser = users.Find(user => user.Name == signInName && user.Password == signInPassword);

                if (loggedInUser != null)
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
                **- SIGN UP -**
                Please, enter your name, email and password:
                """);

                string? userName = null;
                string? userEmail = null;
                string? userPassword = null;

                // Validate name - UPDATED this after the lesson, storing condition in a var
                var validateNameCondition = (string.IsNullOrEmpty(userName) || userName.Length < 3 || !userName.All(char.IsLetter));

                while (validateNameCondition)
                {
                    Console.WriteLine("Name must be at least 3 characters long and contain only letters.");
                    Console.Write("Name: ");
                    userName = Console.ReadLine();

                    // Update the condition after user input
                    validateNameCondition = string.IsNullOrEmpty(userName) || userName.Length < 3 || !userName.All(char.IsLetter);
                }

                // Validate email - UPDATED this after the lesson, storing condition in a var
                var validateEmailCondition = (string.IsNullOrEmpty(userEmail) || !IsValidEmail(userEmail));
                while (validateEmailCondition)
                {
                    Console.WriteLine("Please enter a valid email address.");
                    Console.Write("Email: ");
                    userEmail = Console.ReadLine();

                    // Update the condition after user input
                    validateEmailCondition = string.IsNullOrEmpty(userEmail) || !IsValidEmail(userEmail);
                }

                // Validate password - UPDATED this after the lesson, storing condition in a var
                var validatePasswordCondition = (string.IsNullOrEmpty(userPassword) || userPassword.Length < 6);
                while (validatePasswordCondition)
                {
                    Console.WriteLine("Password must be at least 6 characters long.");
                    Console.Write("Password: ");
                    userPassword = Console.ReadLine();

                    // Update the condition after user input
                    validatePasswordCondition = string.IsNullOrEmpty(userPassword) || userPassword.Length < 6;
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

