using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class NumberGuessingGame
    {
        /*
         1.inputad shemodis ragac ricxvi
         2. outputi aqvs 5 nairi -- 
        too high , high , close
        low , too low
        3. keep track of attempts 
        4. keep track of win/loss stats
         */
        const int MaxAttempts = 7;

        public static void Simulation()
        {
            Console.WriteLine("Hello Player");


            int previousGuess = -100;


            int wins = 0;
            int loses = 0;


            bool hasWon = false;
            bool gameloop = true;
            while (gameloop)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Start of a new game");

                int attempts = 0; // this will also work outside , just for clarity

                Random rnd = new Random();
                int SecretNumber = rnd.Next(1, 201);


                guessingPart(SecretNumber, attempts, previousGuess, out hasWon);

                if (hasWon)
                {
                    wins++;
                    Console.WriteLine($"Total wins : {wins}");
                    Console.WriteLine($"Total loses : {loses}");
                    savingFile(wins, loses);
                }
                else
                {
                    loses++;
                    Console.WriteLine($"Total wins : {wins}");
                    Console.WriteLine($"Total loses : {loses}");
                    savingFile(wins, loses);
                }
                Console.WriteLine("Do you want to finish the game? if yes type y if no type n");
                string response = Console.ReadLine();// every time a console.readline is used it waits for input , i used it twice in if and in if else which breaks logic

                if (response == "y")
                {
                    gameloop = false;
                }
                else if (response == "n")
                {
                    continue;
                }

            }

        }

        public static void guessingPart(int SecretNumber, int attempts, int previousGuess, out bool hasWon)
        {
            while (attempts < MaxAttempts)
            {
                Console.WriteLine("Enter Number from 1 to 200");

                string input = Console.ReadLine();
                bool success = int.TryParse(input, out int guess);

                if (!success)
                {
                    continue; // break here ends game
                }



                if (guess - SecretNumber > 20)
                {
                    Console.WriteLine("Too high");
                    HotCold(previousGuess, guess, SecretNumber);
                    previousGuess = guess;
                    attempts++;
                }
                else if (guess - SecretNumber > 10 && guess - SecretNumber <= 20)
                {
                    Console.WriteLine("High");
                    HotCold(previousGuess, guess, SecretNumber);
                    previousGuess = guess;
                    attempts++;
                }
                else if (guess - SecretNumber <= 10 && guess - SecretNumber > 0)
                {
                    Console.WriteLine("Close-High");
                    HotCold(previousGuess, guess, SecretNumber);
                    previousGuess = guess;
                    attempts++;
                }
                else if (SecretNumber - guess <= 10 && SecretNumber - guess > 0)
                {
                    Console.WriteLine("Close-low");
                    HotCold(previousGuess, guess, SecretNumber);
                    previousGuess = guess;
                    attempts++;
                }
                else if (SecretNumber - guess > 10 && SecretNumber - guess <= 20)
                {
                    Console.WriteLine("Low");
                    HotCold(previousGuess, guess, SecretNumber);
                    previousGuess = guess;
                    attempts++;
                }
                else if (SecretNumber - guess > 20)
                {
                    Console.WriteLine("Too low");
                    HotCold(previousGuess, guess, SecretNumber);
                    previousGuess = guess;
                    attempts++;
                }
                else
                {
                    Console.WriteLine("you are right");
                    hasWon = true;
                    return;
                }
            }
            Console.WriteLine("you are wrong");
            hasWon = false;
        }

        public static void HotCold(int previousguess, int currentguess, int SecretNumber)
        {
            if (Math.Abs(SecretNumber - previousguess) < Math.Abs(SecretNumber - currentguess))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("❄️ Getting colder..");
                Console.ResetColor();

            }
            else if (Math.Abs(SecretNumber - previousguess) > Math.Abs(SecretNumber - currentguess))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("🔥 Getting warmer!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("😐 Same distance!");
            }
        }


        // this saves previous games info for files
        public static void savingFile(int wins, int loses)
        {
            using (StreamWriter file = new StreamWriter("stats.txt", append: true))
            {
                file.WriteLine($"Game was played at {DateTime.Now}");
                file.WriteLine($"Wins : {wins} , Loses : {loses}");
            }
        }

    }



}

