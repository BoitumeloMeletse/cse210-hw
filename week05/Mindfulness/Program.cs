using System;
using System.Collections.Generic;
using System.Threading;

// Base Class
class MindfulnessActivity
{
    protected int duration;
    
    public MindfulnessActivity(int duration)
    {
        this.duration = duration;
    }
    
    public void StartActivity(string activityName, string description)
    {
        Console.WriteLine($"\nStarting {activityName}...");
        Console.WriteLine(description);
        Console.Write("Enter duration (in seconds): ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        Thread.Sleep(2000);
    }
    
    public void EndActivity(string activityName)
    {
        Console.WriteLine($"\nGreat job! You completed {activityName} for {duration} seconds.");
        Thread.Sleep(2000);
    }
}

// Breathing Activity
class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration) : base(duration) { }

    public void PerformBreathingExercise()
    {
        StartActivity("Breathing Exercise", "This activity will help you relax by guiding your breathing.");
        
        for (int i = 0; i < duration / 2; i++)
        {
            Console.WriteLine("Breathe in...");
            Countdown(3);
            Console.WriteLine("Breathe out...");
            Countdown(3);
        }
        
        EndActivity("Breathing Exercise");
    }
    
    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// Reflection Activity
class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need."
    };
    
    public ReflectionActivity(int duration) : base(duration) { }

    public void PerformReflection()
    {
        StartActivity("Reflection Activity", "This activity helps you reflect on moments of strength and resilience.");
        Random rand = new Random();
        string selectedPrompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine("\n" + selectedPrompt);
        
        Countdown(5);
        
        EndActivity("Reflection Activity");
    }
    
    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// Listing Activity
class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are some of your personal heroes?"
    };
    
    public ListingActivity(int duration) : base(duration) { }

    public void PerformListing()
    {
        StartActivity("Listing Activity", "This activity helps you list positive aspects of your life.");
        Random rand = new Random();
        string selectedPrompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine("\n" + selectedPrompt);
        
        Console.Write("Start listing (press Enter after each item, type 'done' to finish):\n");
        int count = 0;
        while (Console.ReadLine().ToLower() != "done")
        {
            count++;
        }
        
        Console.WriteLine($"You listed {count} items!");
        EndActivity("Listing Activity");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();
            if (choice == "4") break;
            
            Console.Write("Enter duration in seconds: ");
            int duration = int.Parse(Console.ReadLine());
            
            switch (choice)
            {
                case "1":
                    new BreathingActivity(duration).PerformBreathingExercise();
                    break;
                case "2":
                    new ReflectionActivity(duration).PerformReflection();
                    break;
                case "3":
                    new ListingActivity(duration).PerformListing();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
