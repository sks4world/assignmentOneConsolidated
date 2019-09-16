using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace assignmentOneConsolidated
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 22;
            printSelfDividingNumbers(a, b);

            int n2 = 5;
            printSeries(n2);

            int n3 = 5;
            printTriangle(n3);

            int[] J = new int[] {1,3 };
            int[] S = new int[] { 1, 3, 3, 2, 2, 2, 2, 2 };
            int r4 = numJewelsInStones(J, S);
            Console.WriteLine(r4);

            int[] arr1 = new int[] { 1, 2, 3, 5,6,7,8,9 };
            int[] arr2 = new int[] { 1, 2, 4, 5 };
            int[] r5 = getLargestCommonSubArray(arr1, arr2);
            string sx = String.Join("",r5);
            Debug.WriteLine($"Longest string found is {sx}", sx);
            foreach (var item in r5)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void printSelfDividingNumbers(int x, int y)
        {
            try
            {
                //Initialize.
                string p;
                int x1;
                int y1;
                int d1;
                int d2;
                int j;
                bool selfDividing;
                int countOfSd;

                //Pseudocode
                p = "This is pseudocode. Initialize a variable selfDividing=true\n";
                p = p + "Read first number in the series of x to y in increments of 1. Lets say it is N1\n";
                p = p + "Find Modulo 10 of first number. It will give the unit place digit as reminder. Lets say it is D1\n";
                p = p + "If unit digit is zero, go to next step break the loop and iterate next number. If unit digit is > 0, do a modulo division of N1 by D1. If result is 0, it divides perfectly. If result is >0, break this inner loop and iterate next number\n";
                p = p + "Do a regular division of first number N1 by 10. If result is < 0, print 'N1 is self dividing'. If result is > 0, repeat previous two steps\n";
                Debug.WriteLine("Assignment 1. Self Dividing Number");
                Debug.WriteLine(p);

                //Read input
                //x1 = 100;
                //y1 = 125;
                //Debug.WriteLine("Enter value for first number x:");
                //x1 = int.Parse(Console.ReadLine());
                //Debug.WriteLine("Enter value for second number y:");
                //y1 = int.Parse(Console.ReadLine());
                x1 = x;
                y1 = y;

                //Iterate
                countOfSd = 0;
                for (int i = x1; i < y1 + 1; i++) //For each number in the given range of x to y
                {
                    selfDividing = true; //Start with a optimistic judgement, this number is selfDividing
                    j = i;
                    while (j > 0) //Use a different variable 'j' to get each digit in the given number
                    {
                        d1 = j % 10; //Find the unit digit of the number. At end of whileloop, j is trimmed of this unit digit to make new j
                        if (d1 == 0) //If unit digit is zero, then this number is not self dividing
                        {
                            selfDividing = false;
                            break;
                        }
                        else
                        {
                            d2 = i % d1; //If unit digit is not zero, then divide the input number x by the unit digit
                            if (d2 > 0) // If it does not perfectly divide, there is a reaminder, this is not self dividing number
                            {
                                selfDividing = false;
                                break;
                            }
                            else
                            {
                                //continue;
                                //selfDividing = true;
                            }
                        }
                        j = j / 10; //Trim the j to cast away the last digit on right and retain the remaining digits on left to repeat the steps above in the while loop
                    }
                    if (selfDividing == true)
                    {
                        Debug.WriteLine($"{i} is self dividing", i);
                        countOfSd += 1;
                    }
                    else
                    {
                        //Debug.WriteLine($"{i} is not self dividing", i);
                    }
                    if (i == y1)
                    {
                        Debug.WriteLine($"There is/are {countOfSd} self dividing numbers", countOfSd);
                    }
                }

                p = "This is the list of Learnings from the assignment and recommendations\n";
                p = p + "Learning 1. Writing a clear Pseudocode speeds up the coding\n";
                p = p + "Learning 2. Using the correct type of loop, like while, for at the right place helps in easy handling\n";
                p = p + "Recommendation: This is a good practice program. Continue kept the program in endless loop. In future, show caution about this when coding \n";
                Debug.WriteLine(p);

            }
            catch
            {
                Console.WriteLine("Exception occurred while computing print SelfDividingNumbers()");
            }
        }

        public static void printSeries(int n)
        {
            try
            {
                //Initialize
                string p;
                int N;
                int n1;
                List<int> serieslist = new List<int>();
                string seriesliststring;

                p = "This is Pseudocode for Assignment One Exercise 2, Number of terms of series for integer \n";
                p = p + "Read the input integer, say it is N. Create an empty array/list\n";
                p = p + "Get first number, i.e 1, say it is n1. Add it to the array and deduct one from it. While n1 > 0, if length of array is < N, repeat the step\n";
                Debug.WriteLine(p);

                //Read input
                //N = 5;
                //Debug.WriteLine("Enter the number of terms to print series, n: ");
                //N = int.Parse(Console.ReadLine());
                N = n;

                for (int i = 1; i < N + 1; i++) //For each number (n1) from 1 to N, add to the array n1 times, array is < N
                {
                    n1 = i; //Use the current number to find the number of times to repeat by deducting one each time until N is reached

                    while (n1 > 0)
                    {
                        if (serieslist.Count < N)
                        {
                            serieslist.Add(i);
                            //Debug.WriteLine(i);
                        }
                        else //Number of terms in the series has reached N
                        {
                            break;
                        }
                        n1 = n1 - 1; // Deduct one from the current number after adding to list.
                    }
                    if (serieslist.Count >= N)
                    {
                        break;
                    }
                }
                //serieslist.ForEach(Console.WriteLine);
                seriesliststring = string.Join(",", serieslist.ToArray());
                Debug.WriteLine($"Series till n= {N} terms is: ", N);
                Debug.WriteLine(seriesliststring);
                p = "Learnings and Recommendations for exercise 2:\n";
                p = p + "1. List operations is very helpful coding knowledge to manage with lesser lines of code\n";
                p = p + "2. Printing List has some iteration logic, sometimes converting to string and printing is easier and serves the purpose\n";
                p = p + "3. While dealing with Multiple loops, writing the comments for each loops purpose helps to easily debug later\n";
                p = p + "4. It is recommended to practice more on List and Array operations, as these seem important for interviews";
            }
            catch
            {
                Console.WriteLine("Exception occurred while computing printSeries()");
            }
        }

        public static void printTriangle(int n)
        {
            try
            {
                //Initialize
                string p;
                int N;
                int n1;
                int numofstars;
                string stars;
                int numofspaces;
                string spaces;

                //Pseudocode
                p = "Pseudo code for inverted triangle. Input is an integer, say N\n";
                p = p + "Number of stars follow the pattern of 1,3,5,7 from bottom to top, it is 2n-1 stars\n";
                p = p + "Use a loop to start from N and decrement till 1, each time create a string that contains 2N-1 stars and print it\n";
                p = p + "Add space to center the stars. Number of spaces on either side is (Top most layer (2N-1) stars minus each layer (2n-1) stars)/2\n";
                Debug.WriteLine(p);

                //Read input
                //N = 5;
                //Debug.WriteLine("Enter the number to print inverse triangle: ");
                //N = int.Parse(Console.ReadLine());
                N = n;
                n1 = N;

                //Iteration
                while (n1 > 0) //Repeat the loop until N reaches 1
                {
                    stars = "";
                    spaces = "";
                    numofstars = (2 * n1) - 1; //Number of stars for the line N
                    for (int i = 1; i < numofstars + 1; i++)
                    {
                        stars = stars + "*"; //Create a string by concatenating stars equal to a measure calculated above for numofstars
                    }
                    numofspaces = (((2 * N) - 1) - ((2 * n1) - 1)) / 2;
                    for (int j = 1; j < numofspaces + 1; j++)
                    {
                        spaces = spaces + " "; //Create a string by concatenating spaces equal to a measure calculated above for numofspaces
                    }
                    Debug.WriteLine(spaces + stars); //print the string of stars to console
                    n1 = n1 - 1; //Decrement the input value N by 1 to restart the while loop
                }

                p = "Learnings and Recommendations\n";
                p = p + "1. Invisible things like spaces need to be considered while thinking of logic. Negative of what we are able to see also to be considered.\n";
                p = p + "2. Memorizing the basic mathematical formulas is helpful. In this case, knowing the formula for odd numbers already is helpful and saved time.\n";
                p = p + "3. Proof reading the code before running is helpful\n";
                p = p + "4. It is recommended to practise all types of string operations\n";
                Debug.WriteLine(p);

            }
            catch
            {
                Console.WriteLine("Exception occurred while computing printTriangle()");
            }
        }

        public static int numJewelsInStones(int[] J, int[] S)
        {
            try
            {
                //Initialize
                string p;
                int countJinS;
                int[] j1 = J;
                int[] s1 = S;


                //Pseudocode
                p = "Pseudocode for numJewlsInStones\n";
                p = p + "Iterate through the list of Jewels and for each item, iterate through the list of Stones to find a match\n";
                p = p + "For each match found, increment a counter and print the counter\n";
                Debug.WriteLine(p);

                //Code
                countJinS = 0;
                foreach (int i in j1)
                {
                    //Debug.WriteLine($"{i}", i);
                    foreach (int j in s1)
                    {
                        if (j == i)
                        {
                            countJinS += 1;
                        }
                    }
                }
                Debug.WriteLine($"Number of Jewels in Stones is {countJinS}", countJinS);
                p = "Learnings and recommendations\n";
                p = p + "1. Learning the techniques to handle large lists will give confidence. Right now, simple loops are used as it is small array\n";
                p += "2. It is helpful to know all string functions by heart\n ";
                p += "3. Strings and arrays have interchangeable needs\n";
                p += "4.It is recommended to practise more on the arrays\n ";
                Debug.WriteLine(p);
            }
            catch
            {
                Console.WriteLine("Exception occurred while computing numJewelsInStones()");
            }
            return 0;
        }

        public static int[] getLargestCommonSubArray(int []a, int []b)
        {
            int[] r5 = null;

            try
            {
                //Initialize
                string p;
                string str1;
                string str2;
                int len;
                int[] a1 = null;

                //Pseudocode
                p = "Pseudocode: read both the input arrays and convert into two strings S1 and S2\n";
                p = p + "For the length of the string, find if the string S1 is contained in the string S2\n";
                p = p + "If present, break and convert the string back to array and print the longest array found\n";
                p = p + "If not present, drop the last character in the string and repeat the above step\n";
                p = p + "If no string found, then print, first array is not found in the second array";
                Debug.WriteLine(p);

                //Code
                str1 = string.Join("", a);
                str2 = string.Join("", b);
                len = str1.Length;



                for (int i=len-1; i>0; i--)
                {
                    if(str2.Contains(str1))
                    {
                        //Debug.WriteLine($"Longest string found is {str1}", str1);
                        break;
                    }
                    else
                    {
                        str1 = str1.Remove(i, 1);
                    }
                }
                if (str1.Length > 0)
                {
                    char[] charArr = str1.ToCharArray();
                    a1 = Array.ConvertAll(str1.Split(' '), int.Parse);
                    r5 = a1;
                    //r5 = Array.ConvertAll(charArr c => int.Parse(c));
                    foreach (var item in a1)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }

                //Learnings and Recommendations
                p = "Learnings and recommendations\n";
                p = p + "1. Learning the techniques to handle integer and string arrays is needed\n";
                p += "2. It is helpful to know joining an array into string and vice versa by heart\n ";
                p += "3. Strings and integer arrays have interchangeable needs\n";
                p += "4.It is recommended to practise more on the string to array conversion\n";
                Debug.WriteLine(p);
            }
            catch
            {
                Console.WriteLine("Exception occurred while computing getLargestCommonSubArray()");
            }

            
            return r5;
        }
    }
}
