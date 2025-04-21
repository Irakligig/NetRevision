using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day2
{
    /*this is a game of tictactoe. gameflow looks likes this : 
     in while(!gameover) { 
        1. ask the user for the size of the board
     2. create a board of size n*n
     3. ask the user for the coordinates of the X,Y
    4. check if isdraw -- separate function
    5. check if haswon -- separate function , basically if you put something
    inside the board , will it become a win?
    6. if both of them fail , continue while loop
    }
     
     
     
     
     */
    public class TicTacToe
    {
        public static void Simulation()
        {
            Console.WriteLine("What kind of tictactoe do you want?");
            int n = Convert.ToInt32(Console.ReadLine());

            char[,] array = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = ' ';
                }
            }

            bool gameover = false;
            bool playerOnesTurn = true;
            string whoseTurn;
            char symbol = 'X';
            while (!gameover)
            {
                Console.WriteLine("Enter Coordinates for X");
                int CordsX = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Coordinates for Y");
                int CordsY = Convert.ToInt32(Console.ReadLine());

                whoseTurn = playerOnesTurn ? "Player 1" : "Player 2";

                symbol = playerOnesTurn ? 'X' : 'O';

                gameover = hasWon(array, CordsX, CordsY, symbol, whoseTurn);
                if (isDraw(array))
                {
                    Console.WriteLine("Draw");
                    ShowCase(array);
                    break;
                }
                else if (gameover)
                {
                    Console.WriteLine($"{whoseTurn} wins");
                    ShowCase(array);
                    break;
                }
                else
                {
                    playerOnesTurn = !playerOnesTurn;
                }
            }
        }
        public static void ShowCase(char[,] x)
        {
            int n = x.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Print the value of the cell with spacing for better readability
                    Console.Write($" {x[i, j]} ");

                    // Print vertical borders except for the last column
                    if (j < n - 1)
                        Console.Write("|");
                }

                Console.WriteLine();

                // Print horizontal borders except for the last row
                if (i < n - 1)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write("---");

                        // Print "+" between columns
                        if (j < n - 1)
                            Console.Write("+");
                    }
                    Console.WriteLine();
                }
            }
        }

        public static bool DiagonalChecking(char[,] x, char xoro)
        {
            bool haswon = false;
            int firstdiagonal = 0;
            int seconddiagonal = 0;
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    if (i == j && x[i, j] == xoro)
                    {
                        firstdiagonal++;
                    }
                    if (i + j == x.GetLength(1) - 1 && x[i, j] == xoro)
                    {
                        seconddiagonal++;
                    }
                }
            }
            if (firstdiagonal == x.GetLength(1) || seconddiagonal == x.GetLength(1))
            {
                haswon = true;
                return haswon;
            }
            else
            {
                return haswon;
            }
        }
        public static bool isDraw(char[,] array)
        {
            bool isfull = false;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0);j++)
                {
                    if (array[i,j] == ' ')
                    {
                        return isfull;
                    }
                }
            }
            return !isfull;
        }

        public static bool hasWon(char[,] array, int cordsX, int cordsY, char symbol, string whoseTurn)
        {
            int n = array.GetLength(0);
            if (cordsX < 0 || cordsX > n - 1 || cordsY < 0 || cordsY > n - 1)
            {
                Console.WriteLine("out of bounds , try again");
                return false;
            }
            if (array[cordsY, cordsX] == 'X' || array[cordsY, cordsX] == 'O')
            {
                Console.WriteLine($"Try Again {whoseTurn}");
                return false;
            }
            else
            {
                int howMany = 0;
                array[cordsY, cordsX] = symbol;
                ShowCase(array);
                for (int i = 0; i < n; i++)
                {
                    if (array[i, cordsX] == symbol)
                    {
                        howMany++;
                    }
                }
                if (howMany == n)
                {
                    Console.WriteLine($"{whoseTurn} wins");
                    return true;
                }
                else
                {
                    if (DiagonalChecking(array, symbol))
                    {
                        Console.WriteLine($"{whoseTurn} wins");
                    }
                    else
                    {
                        howMany = 0;
                        for (int j = 0; j < n; j++) // i was doing it with two loops but with one iteration , which isnt necessary
                        {
                            if (array[cordsY, j] == symbol) howMany++;
                        }
                        if (howMany == n)
                        {
                            Console.WriteLine($"{whoseTurn} wins");
                            return true;
                        }

                    }

                }
                return false;
            }
        }
    }
   

    
    /*
     bugs:
    1. only one diagonal is checked 
    2.

     */
}


