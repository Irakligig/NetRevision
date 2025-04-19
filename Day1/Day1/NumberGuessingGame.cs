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

        public static void Simulation()
        {
            Console.WriteLine("Hello Player");
            int attempts = 0;
            Random rnd = new Random();
            int SecretNumber = rnd.Next(1, 201);
            int previousGuess = -100;

            guessingPart(SecretNumber,attempts,previousGuess);
        }

        public static void guessingPart(int SecretNumber, int attempts , int previousGuess)
        {
            while (attempts < 7)
            {
                Console.WriteLine("Enter Number from 1 to 200");
                int guess = Convert.ToInt32(Console.ReadLine());

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
                    Console.WriteLine("game is over");
                    return;
                }
            }
        }

        public static void HotCold(int previousguess , int currentguess , int SecretNumber)
        {
            if (Math.Abs(SecretNumber - previousguess) < Math.Abs(SecretNumber - currentguess))
            {
                Console.WriteLine("❄️ Getting colder..");
            }
            else if (Math.Abs(SecretNumber - previousguess) > Math.Abs(SecretNumber - currentguess))
            {
                Console.WriteLine("🔥 Getting warmer!");
            }
            else
            {
                Console.WriteLine("😐 Same distance!");
            }
        }

    }
    


}

