Console.WriteLine("**- WELCOME TO MO'S BANK -**");

Console.WriteLine("""
    ** MAIN-MENU **
    Select one of these options:
    1. Sign In
    2. Sign Up
    q. Quit
    """);

Console.Write("Insert option: ");
String? userInput = Console.ReadLine();

if (userInput == "1")
{
    Console.WriteLine("""
        **- SIGN IN -**
        Please, enter your name and password:
        """);
    Console.Write("Name: ");
    String? userName = Console.ReadLine();
    Console.WriteLine("Password: ");
    String? userPassword = Console.ReadLine();
    Console.WriteLine(userName + " " + userPassword);
} else if (userInput == "2")
{
    Console.WriteLine("""
        **- SIGN UP -**
        Please, enter your name, email and password:
        """);
    Console.Write("Name: ");
    String? userName = Console.ReadLine();
    Console.Write("Email: ");
    String? userEmail = Console.ReadLine();
    Console.WriteLine("Password: ");
    String? userPassword = Console.ReadLine();
    Console.WriteLine("You have successfully signed up with Mo's Bank!");
} else if (userInput == "q")
    {
    Console.WriteLine("""
        **- QUIT -**
        Thank you for using Mo's banking!
        """);
    return;
}
else
{
    Console.WriteLine("Oops! Something went wrong. Please, try again!");
}