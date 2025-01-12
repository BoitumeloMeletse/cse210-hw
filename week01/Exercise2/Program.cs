using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);

        // Initialize the letter grade variable
        string letter = "";

        // Determine the letter grade using if-else statements
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Add "+" or "-" to the grade based on the last digit
        string gradeSign = "";
        if (letter != "F") // "+" or "-" are not valid for "F"
        {
            int lastDigit = grade % 10;

            if (lastDigit >= 7)
            {
                gradeSign = "+";
            }
            else if (lastDigit < 3)
            {
                gradeSign = "-";
            }
        }

        // Print the full grade with sign
        Console.WriteLine($"Your grade is {letter}{gradeSign}.");

        // Check if the student passed or failed
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep it up! Try harder next time.");
        }
    }
}
