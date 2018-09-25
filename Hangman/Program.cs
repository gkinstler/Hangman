using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string wikiData = GetWikipediaData();
            List<string> words = GetWords(wikiData);


            string secretWord = GetRandomWord(words);
            List<char> incorrectGuesses = new List<char>();
            List<char> correctGuesses = new List<char>();

            Console.WriteLine("Let's play Hangman!");

            DrawUnderscores(secretWord, correctGuesses);
            DrawDude(incorrectGuesses.Count);

            while (incorrectGuesses.Count < 6)
            {
                Console.WriteLine("Please guess a letter:");
                string strGuess = Console.ReadLine();

                Console.Clear();

                char guess = strGuess[0];

                if (secretWord.Contains(guess.ToString()) && !correctGuesses.Contains(guess))
                {
                    correctGuesses.Add(guess);
                }
                else if (!secretWord.Contains(guess.ToString()) && !incorrectGuesses.Contains(guess))
                {
                    incorrectGuesses.Add(guess);
                }

                DrawUnderscores(secretWord, correctGuesses);
                DrawDude(incorrectGuesses.Count);

                Console.Write("Incorrect Guesses: ");
                foreach (char letter in incorrectGuesses)
                {
                    Console.Write(letter + " ");
                }
                Console.WriteLine();
            }

        }

        static void DrawUnderscores(string secretWord, List<char> correctGuesses)
        {
            foreach (char letter in secretWord)
            {
                if (correctGuesses.Contains(letter))
                {
                    Console.Write(letter + " ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }
            Console.WriteLine();
        }

        static void DrawDude(int incorrectGuessCount)
        {
                string dude =
"    0000000000000\n" +
"    0           0\n" +
"    0           1\n" +
"    0          1 1\n" +
"    0           1\n" +
"    0          324\n" +
"    0         3 2 4\n" +
"    0        3  2  4\n" +
"    0          5 6\n" +
"    0         5   6\n" +
"    0        5     6\n" +
"    0       5       6\n" +
"    0\n" +
"    0\n" +
" 0000000\n";

            foreach (char c in dude)
                {
                    int.TryParse(c.ToString(), out int dudeNumber);

                    if (dudeNumber <= incorrectGuessCount)
                    {
                        Console.Write(c);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
        }

        static string GetWikipediaData()
        {
            WebClient webClient = new WebClient();
            string str = webClient.DownloadString("https://en.wikipedia.org/wiki/United States");
            return str;
        }

        static List<string> GetWords(string htmlString)
        {
            string[] arr = htmlString.Split(' ');
            List<string> words = arr.Where(x => x.Where(y => !char.IsLetter(y)).Count() == 0).ToList();
            return words.Distinct().ToList();
        }

        static string GetRandomWord(List<string> words)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(words.Count);
            return words[randomNumber];
        }

    }
}
