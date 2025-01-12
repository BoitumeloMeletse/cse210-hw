using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store the numbers
        List<int> numbers = new List<int>();
        
        // Prompt the user to enter numbers
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        while (true)
        {
            // Ask the user for a number
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            // Stop if the user enters 0
            if (number == 0)
            {
                break;
            }

            // Add the number to the list
            numbers.Add(number);
        }

        // Compute the sum, average, and largest number
        int sum = 0;
        int largestNumber = int.MinValue;

        foreach (int num in numbers)
        {
            sum += num;
            if (num > largestNumber)
            {
                largestNumber = num;
            }
        }

        double average = sum / (double)numbers.Count;

        // Output the results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");

        // Stretch Challenge: Find the smallest positive number
        int smallestPositiveNumber = int.MaxValue;
        foreach (int num in numbers)
        {
            if (num > 0 && num < smallestPositiveNumber)
            {
                smallestPositiveNumber = num;
            }
        }
        
        if (smallestPositiveNumber != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositiveNumber}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers.");
        }

        // Stretch Challenge: Sort the numbers in ascending order and display the sorted list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
