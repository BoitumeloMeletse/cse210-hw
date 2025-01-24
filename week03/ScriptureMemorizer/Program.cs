using System;
using System.Collections.Generic;

// Reference Class
public class Reference
{
    private string book;
    private int startChapter, startVerse, endChapter, endVerse;

    public Reference(string book, int startChapter, int startVerse, int endChapter = 0, int endVerse = 0)
    {
        this.book = book;
        this.startChapter = startChapter;
        this.startVerse = startVerse;
        this.endChapter = endChapter > 0 ? endChapter : startChapter;
        this.endVerse = endVerse > 0 ? endVerse : startVerse;
    }

    public override string ToString()
    {
        return endChapter == startChapter && endVerse == startVerse
            ? $"{book} {startChapter}:{startVerse}"
            : $"{book} {startChapter}:{startVerse}-{endChapter}:{endVerse}";
    }
}

// Word Class
public class Word
{
    private string text;
    private bool isHidden;

    public Word(string text)
    {
        this.text = text;
        this.isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public override string ToString()
    {
        return isHidden ? new string('_', text.Length) : text;
    }
}

// Scripture Class
public class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        this.words = new List<Word>();
        foreach (string word in text.Split(' '))
        {
            words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.WriteLine(reference.ToString());
        foreach (Word word in words)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < count)
        {
            int index = random.Next(words.Count);
            if (!words[index].ToString().Contains("_"))
            {
                words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public bool IsFullyHidden()
    {
        foreach (Word word in words)
        {
            if (!word.ToString().Contains("_"))
            {
                return false;
            }
        }
        return true;
    }
}

// Program Class
class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 3, 6);
        Scripture scripture = new Scripture(reference, "Trust in the Lord with all your heart and lean not on your own understanding");

        Console.Clear();
        scripture.Display();

        while (true)
        {
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
            Console.Clear();
            scripture.Display();

            if (scripture.IsFullyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Program ending.");
                break;
            }
        }
    }
}
