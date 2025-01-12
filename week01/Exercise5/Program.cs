using System;

class Program
{
    // Function 1: DisplayWelcome
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function 2: PromptUserName
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function 3: PromptUserNumber
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // Function 4: SquareNumber
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function 5: DisplayResult
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }

    // Main Method: Calling functions in sequence
    static void Main(string[] args)
    {
        // Call DisplayWelcome
        DisplayWelcome();

        // Call PromptUserName and store the result
        string userName = PromptUserName();

        // Call PromptUserNumber and store the result
        int userNumber = PromptUserNumber();

        // Call SquareNumber with the user's number and store the result
        int squaredNumber = SquareNumber(userNumber);

        // Call DisplayResult to show the final result
        DisplayResult(userName, squaredNumber);
    }
}
