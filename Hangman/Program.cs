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

            while(incorrectGuesses.Count < 6)
            {
                Console.WriteLine("Please guess a letter:");
                string strGuess = Console.ReadLine();

                char guess = strGuess[0];

                if (secretWord.Contains(guess.ToString()))
                {
                    correctGuesses.Add(guess);
                }
                else
                {
                    incorrectGuesses.Add(guess);
                }

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
            

        }
    }
}
