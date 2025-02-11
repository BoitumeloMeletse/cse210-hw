using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetProgress();

    public override string ToString()
    {
        return $"{Name} - {GetProgress()}";
    }
}

public class SimpleGoal : Goal
{
    private bool _isComplete = false;

    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"{Name} completed! You earned {Points} points.");
        }
        else
        {
            Console.WriteLine($"{Name} is already completed.");
        }
    }

    public override bool IsComplete() => _isComplete;
    public override string GetProgress() => _isComplete ? "[X] Completed" : "[ ] Not completed";
}

public class EternalGoal : Goal
{
    private int _timesRecorded = 0;

    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        _timesRecorded++;
        Console.WriteLine($"{Name} recorded! You earned {Points} points. Total completions: {_timesRecorded}.");
    }

    public override bool IsComplete() => false;
    public override string GetProgress() => $"Completed {_timesRecorded} times";
}

public class ChecklistGoal : Goal
{
    private int _timesCompleted = 0;
    private int _targetCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
        int totalPoints = Points;

        if (_timesCompleted == _targetCount)
        {
            totalPoints += _bonusPoints;
            Console.WriteLine($"Bonus achieved! You earned an extra {_bonusPoints} points.");
        }

        Console.WriteLine($"{Name} recorded! You earned {totalPoints} points.");
    }

    public override bool IsComplete() => _timesCompleted >= _targetCount;
    public override string GetProgress() => $"Completed {_timesCompleted}/{_targetCount}";
}

public class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int totalScore = 0;

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordGoal(string goalName)
    {
        Goal goal = goals.Find(g => g.Name == goalName);
        if (goal != null)
        {
            goal.RecordEvent();
            totalScore += goal.Points;
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nGoals:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal);
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nTotal Score: {totalScore}");
    }
}
