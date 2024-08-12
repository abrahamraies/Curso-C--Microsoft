using System;
using System.Text;

class Program
{
    static void Main()
    {
        string input = "there are snakes at the zoo";

        Console.WriteLine(input);
        Console.WriteLine(ReverseSentence(input));
    }

    static string ReverseSentence(string sentence)
    {
        StringBuilder reversedSentence = new StringBuilder();
        string[] words = sentence.Split(' ');

        foreach (string word in words)
        {
            reversedSentence.Append(ReverseWord(word)).Append(' ');
        }

        return reversedSentence.ToString().TrimEnd();
    }

    static string ReverseWord(string word)
    {
        StringBuilder reversedWord = new StringBuilder();

        for (int i = word.Length - 1; i >= 0; i--)
        {
            reversedWord.Append(word[i]);
        }

        return reversedWord.ToString();
    }
}
