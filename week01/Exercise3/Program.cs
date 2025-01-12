using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialize the random number generator
        Random randomGenerator = new Random();

        // Loop to keep the game running until the user chooses to stop
        string playAgain = "yes";
        while (playAgain.ToLower() == "yes")
        {
            // Generate a random magic number between 1 and 100
            int magicNumber = randomGenerator.Next(1, 101);

            // Initialize variables
            int guess = 0;
            int numberOfGuesses = 0;

            Console.WriteLine("Welcome to Guess My Number!");
            Console.WriteLine("I have picked a number between 1 and 100. Try to guess it!");

            // Loop to ask for guesses until the user guesses the magic number
            while (guess != magicNumber)
            {
                // Ask for the user's guess
                Console.Write("What is your guess? ");
                string userInput = Console.ReadLine();
                
                // Validate and parse the user's input
                if (int.TryParse(userInput, out guess))
                {
                    numberOfGuesses++;

                    // Check if the guess is higher, lower, or correct
                    if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine($"You guessed it! The magic number was {magicNumber}. It took you {numberOfGuesses} guesses.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }

            // Ask the user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }

        // Thank the user for playing
        Console.WriteLine("Thank you for playing! Goodbye!");
    }
}
