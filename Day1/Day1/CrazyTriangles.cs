using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class CrazyTriangles
    {
        /*
         Problems like this are usually solved in similar fashion
        1. fill the array with empty spaces
        2. for every row 
        we want to find out the start position of the first star
        and the number of stars we want to print (this differs with different triangles)
        3. and we iterate every row from 0 to amount of starts
        4. and we print start on array[i,startposition + j(indexer of row iteration)]
        5. this will print stars as many times as we want


        int mid
        for()
        {
            int stars;
            int startposition;
            for(from j = 0 to stars){
                    array[i, startpos + j]
                }
        }
         */



        public static void DiamondPattern(int n)
        {
            char[,] array = new char[n, n];

            // filling array with empty spaces
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = ' ';
                }
            }

            int mid = n / 2;
            for (int i = 0; i < n; i++)
            {
                int startposition;
                int stars;

                // we want to find out if row is in apper side or lower side
                if (i <= mid)
                {
                    startposition = mid - i;
                    stars = 2 * i + 1;
                }
                else
                {
                    int modul = n - 1 - i;
                    startposition = mid - modul;
                    stars = 2 * modul + 1;
                }

                for (int j = 0; j < stars; j++) // for each star
                {
                    // we want to find out the position of the star
                    // startposition is the first star position
                    // j is the number of stars we have already printed
                    // so we can calculate the position of the star
                    // by adding startposition and j
                    // and we want to print the star in the same row
                    // so we use i as the row number
                    {
                        array[i, startposition + j] = '*';
                    }
                }
            }
        }

        public static void RotatedTriangle(int n)
        {
            char[,] array = new char[n, n];
            // filling array with empty spaces
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = ' ';
                }
            }


            for (int i = 0; i < n; i++)
            {
                int startPosition = n - 1 - i;
                int stars = i + 1;
                for (int j = 0; j < stars; j++)
                {
                    array[i, startPosition + j] = '*';
                }
            }
        }

        public static void PascalTriangle(int n )
        {
            int[,] array = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= 0; j++)
                {
                    if (i == j || j == 0)
                    {
                        array[i, j] = 1;
                    }
                    else 
                    {
                        array[i , j] = array[i - 1, j - 1] + array[i - 1, j];
                    }
                }
            }
        }

    }
}
