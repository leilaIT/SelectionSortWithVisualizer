using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SelectionSortWithVisualizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] visualizerSize = { 29, 120 }; // rows and columns of console

            Random rnd = new Random();
            int[] arr = new int[visualizerSize[1]];
            int temp = 0;
            int currSwapIndex = 0; // index it is going to get swapped with
            int pastSwapIndex = 0;
            int leastNumber = 0; // this is the least number

            for (int x = 0; x < arr.Length; x++)
                arr[x] = rnd.Next(visualizerSize[0]) + 1;

            // this line just sets the window size to always display in a 
            // 120 * 30 characters in size
            Console.SetWindowSize(visualizerSize[1], visualizerSize[0] + 1);

            #region Visualizing initial display
            for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
            {
                for (int b = 0; b < arr.Length; b++) // dictate number of columns
                {
                    if (arr[b] >= a)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
            }
            Console.Write("To be sorted using selection sort... Press any key to begin...");
            Console.ReadKey();
            //Console.Clear(); 
            #endregion


            for (int x = 0; x < arr.Length - 1; x++)
            {
                leastNumber = arr[x];
                currSwapIndex = -1;
                for (int y = x + 1; y < arr.Length; y++)
                /* 
                 * inner loop
                 * actively searches for the index to swap with
                 */
                {

                    #region Visualizing Column Selection
                    for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                    {
                        for (int b = x; b <= y; b++) // dictate number of columns
                        {
                            if (b == y || b == x)
                            {
                                Console.SetCursorPosition(b, a - 1);
                                if (b == y)
                                    Console.ForegroundColor = ConsoleColor.Red;
                                else if (b == x)
                                    Console.ForegroundColor = ConsoleColor.Blue;

                                if (arr[b] > visualizerSize[0] - a)
                                    Console.Write("*");
                                else
                                    Console.Write(" ");
                            }
                        }
                    }
                    Console.SetCursorPosition(0, 29);
                    Console.Write("Pass {0} : Searching . . . x {0} y {1}                                 ", x, y);
                    //Console.ReadKey();
                    //Thread.Sleep(50);
                    //Console.Clear(); 
                    #endregion

                    if (leastNumber >= arr[y])
                    {
                        leastNumber = arr[y];
                        pastSwapIndex = currSwapIndex;
                        currSwapIndex = y;

                        #region Visualizing selected column
                        for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                        {
                            for (int b = pastSwapIndex; b <= currSwapIndex; b++) // dictate number of columns
                            {
                                if ((b == currSwapIndex || b == pastSwapIndex) && b > 0)
                                {
                                    Console.SetCursorPosition(b, a - 1);
                                    if (b == currSwapIndex)
                                        Console.ForegroundColor = ConsoleColor.Green;
                                    else if (b == pastSwapIndex)
                                        Console.ResetColor();

                                    if (arr[b] > visualizerSize[0] - a)
                                        Console.Write("*");
                                    else
                                        Console.Write(" ");
                                }
                            }
                        }
                        Console.SetCursorPosition(0, 29);
                        Console.Write("Pass {0} : Remembering . . .                                           ", x);
                        //Console.ReadKey();
                        //Thread.Sleep(50);
                        //Console.Clear(); 
                        #endregion
                    }

                    #region Visualizing reset of prescanned column
                    for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                    {
                        for (int b = y; b < y + 1; b++) // dictate number of columns
                        {
                            if (b != currSwapIndex)
                            {
                                Console.SetCursorPosition(b, a - 1);
                                Console.ResetColor();

                                if (arr[b] > visualizerSize[0] - a)
                                    Console.Write("*");
                                else
                                    Console.Write(" ");
                            }
                        }
                    }
                    //Console.ReadKey();
                    //Thread.Sleep(50);
                    //Console.Clear(); 
                    #endregion
                }

                if (currSwapIndex > x)
                {
                    temp = arr[x];
                    arr[x] = arr[currSwapIndex];
                    arr[currSwapIndex] = temp;

                    pastSwapIndex = currSwapIndex;
                }

                #region Visualizing Swap display
                for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                {
                    for (int b = x; b <= currSwapIndex; b++) // dictate number of columns
                    {
                        Console.SetCursorPosition(b, a - 1);
                        if (b == x || b == currSwapIndex)
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        else
                            Console.ResetColor();

                        if (arr[b] > visualizerSize[0] - a)
                            Console.Write("*");
                        else
                            Console.Write(" ");
                    }
                }
                Console.SetCursorPosition(0, 29);
                Console.Write("Pass {0} : Swapping . . .                                             ", x);
                //Console.ReadKey();
                //Thread.Sleep(1000);
                //Console.Clear();
                #endregion

                #region Visualizing reset of past swap column
                for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                {
                    for (int b = pastSwapIndex; b < pastSwapIndex + 1; b++) // dictate number of columns
                    {
                        Console.SetCursorPosition(b, a - 1);
                        Console.ResetColor();

                        if (arr[b] > visualizerSize[0] - a)
                            Console.Write("*");
                        else
                            Console.Write(" ");
                    }
                }
                //Thread.Sleep(50);
                #endregion
            }


            Console.SetCursorPosition(0, 29);
            Console.Write("Done!!!!!!!!!                                              ");
            Console.ReadKey();
        }
    }
}
