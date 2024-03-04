class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
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

                Console.Write("Name: ");
                string? signInName = Console.ReadLine();

                Console.Write("Password: ");
                string? signInPassword = Console.ReadLine();

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

                Console.Write("Name: ");
                string? userName = Console.ReadLine();

                Console.Write("Email: ");
                string? userEmail = Console.ReadLine();

                Console.Write("Password: ");
                string? userPassword = Console.ReadLine();

                User newUser = new User { Name = userName, Email = userEmail, Password = userPassword };
                users.Add(newUser);

                Console.WriteLine("You have successfully signed up with Mo's Bank!");
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

