using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCowsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string randomNumber = GetRandomNumber();
            
            List<Guess> guesses = new List<Guess>();

            string guessAttempt = "";

            while (guessAttempt != randomNumber)
            {
                if (guesses.Count == 7)
                {
                    break;
                }

                guessAttempt = GetUserGuess();
                Guess guess = new Guess() { Value = guessAttempt };
                guesses.Add(guess);

                WriteGuessesSoFar(randomNumber, guesses);
            }


            string winMessage;
            if (guessAttempt == randomNumber)
            {
                winMessage = "You win!";
            }
            else
            {
                winMessage = $"Seven Guesses, You Lose! The number was {randomNumber}.";
            }

            Console.WriteLine(winMessage);

            
        }

        private static void WriteGuessesSoFar(string randomNumber, List<Guess> guesses)
        {
            Console.Clear();
            Console.WriteLine(" GUESS |  BULLS  |  COWS");
            Console.WriteLine("-------|---------|-------");
            for (int i = 0; i < guesses.Count; i++)
            {
                Console.Write($" {guesses[i].Value}  |" +
                              $"    {guesses[i].CountBullsAndCows(randomNumber)[0]}    |" +
                              $"    {guesses[i].CountBullsAndCows(randomNumber)[1]}\n");
            }
            Console.WriteLine();
        }

        private static string GetUserGuess()
        {
            Console.WriteLine("What is your guess? ");

            string guess = "";
            int attempts = 0;

            while(guess.Length != 4)
            {
                if (attempts > 0)
                {
                    Console.Write("Guess must be 4 digits: ");
                }
                attempts++;
                
                guess = Console.ReadLine();

                if (!int.TryParse(guess, out int temp))
                {
                    guess = "";
                }
            }

            return guess;
        }

        private static string GetRandomNumber()
        {
            string randomNumber = "";

            Random rng = new Random();

            while (randomNumber.Length < 4)
            {
                string newDigit = rng.Next(10).ToString();

                if (!randomNumber.Contains(newDigit))
                {
                    randomNumber += newDigit;
                }
            }

            return randomNumber;
        }
    }
}
