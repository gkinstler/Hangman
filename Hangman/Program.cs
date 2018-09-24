using System;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string secretWord = "password";
            List<char> incorrectGuesses = new List<char>();
            List<char> correctGuesses = new List<char>();

            Console.WriteLine("Let's play Hangman!");

            DrawUnderscores(secretWord, correctGuesses);

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
                else if (secretWord.Contains(guess.ToString()) && !incorrectGuesses.Contains(guess))
                {
                    incorrectGuesses.Add(guess);
                }

                DrawUnderscores(secretWord, correctGuesses);

                Console.Write("Incorrect Guesses: ");
                foreach (char letter in incorrectGuesses)
                {
                    Console.Write(letter + " ");
                }

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
"    0";            
            foreach(char c in dude)
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

    }
}
