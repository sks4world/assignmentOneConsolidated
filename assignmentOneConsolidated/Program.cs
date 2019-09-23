using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

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

            solvePuzzle();
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

        public static void solvePuzzle()
        {
            try
            {
                //Initialize
                string p;
                string str1="UBER", str2="COOL", str3="UNCLE";
                int leng = str1.Length + str2.Length;
                int[] inNum = new int[leng+1];
                int[] str1Arr = new int[str1.Length], str2Arr = new int[str2.Length], str3Arr = new int[str3.Length];
                int sum = 0, co = 0, val = 0, valx1 = 0, chosen=0;
                string str = null, strx1 = null;
                bool fnd1 = false, fnd2 = false, fnd3 = false, fnd = false, fnd4=false;

                //Pseudocode
                p = "Read input strings, count number of characters, create an array with random numbers\n" +
                    "Iterate all three strings together, pick last digit, assign values for string 1 and string 2 last character and get string 3 last digit by adding the two\n" +
                    "If there are repeating characters within, assign same value. Repeat the same for last but one characters\n" +
                    "The puzzle is solved";
                Debug.WriteLine(p);

                //Code
                //Random rnd = new Random();
                int c = 0;
                for (int i=0;i<= leng; i++)
                {
                    //inNum[i] = rnd.Next(1, 10);
                    if (i == leng - 1)
                    {
                        c = 1;
                    }
                    else
                    {
                        c += 1;
                    }
                    inNum[i] = c;
                    //Debug.WriteLine(inNum[i]);
                }

                Dictionary<string, int> strval = new Dictionary<string, int>();

                for (int i = str3.Length -1; i >= 0; i--)
                {
                    for (int j = str2.Length -1; j >= 0; j--)
                    {
                        for (int k = str1.Length -1; k >= 0; k--)
                        {
                            if ((i == str3.Length - 1) & (j == str2.Length - 1) & (k == str1.Length - 1)) //Unit digit in each string
                            {
                                //str1Arr[k] = inNum[1];//Pick a number for first string and second string unit digit
                                //str2Arr[j] = inNum[2]; //Implemented for loop to pick number
                                for (int ix = 0; ix<=leng;ix++)
                                {
                                    for (int iy = leng; iy>=0;iy--)
                                    {
                                        if (inNum[ix] + inNum[iy] > 10)
                                        {
                                            str1Arr[k] = inNum[ix];
                                            str2Arr[j] = inNum[iy];
                                            inNum[ix] = 0;
                                            inNum[iy] = 0; //Make picked numbers as 0 to avoid picking again
                                        }
                                    }
                                }
                                sum = str1Arr[k] + str2Arr[j]; 
                                if (sum > 0)
                                {
                                    if (sum > 9) //If Sum is > 9, give unit digit to unit place and carry over the tenth digit to tenth place
                                    {
                                        str3Arr[i] = sum % 10; // Fix value of third string unit digit
                                        co = sum / 10; //Use carryover to add to tenth place digit
                                    }
                                    else //single digit number 
                                    {
                                        str3Arr[i] = sum;
                                        co = 0;
                                    }
                                }
                                else //sum < 0
                                {
                                    Debug.WriteLine("Negative number has to be handled");
                                }
                                for (int x = 0; x <= leng; x++) //Check if chosen number is in random numbers array and replace with 0 to avoid use
                                {
                                    if (inNum[x]==str3Arr[i])
                                    {
                                        inNum[x] = 0; // Set to zero to avoid same number used again
                                    }
                                }
                                Debug.WriteLine(str1Arr[k]);
                                Debug.WriteLine(str2Arr[j]);
                                Debug.WriteLine(str3Arr[i]);
                                Debug.WriteLine(k);
                                Debug.WriteLine(j);
                                Debug.WriteLine(i);

                                //Store the key value pair in a dictionary to address repeating characters
                                str = str1.Substring(str1.Length - 1, 1);
                                val = str1Arr[k];
                                strval.Add(str, val);
                                //Next set for string 2
                                str = str2.Substring(str2.Length - 1, 1);
                                val = str2Arr[j];
                                strval.Add(str, val);
                                //Next set for string 3
                                str = str3.Substring(str3.Length - 1, 1);
                                val = str3Arr[i];
                                strval.Add(str, val);
                                
                            }

                            //printvalues();
                            
                            if ((i == str3.Length - 2) & (j == str2.Length - 2) & (k == str1.Length - 2)) //Tenth digit in each string
                            {
                                //Check if the character in tenth digit has a set value, do it by dictionary lookup
                                str = str1.Substring(str1.Length - 2, 1);
                                if (strval.ContainsKey(str))
                                {
                                    val = strval[str];
                                    fnd1 = true;
                                    str1Arr[k] = val;
                                }
                                
                                //Repeat for string 2
                                str = str2.Substring(str2.Length - 2, 1);
                                if (strval.ContainsKey(str))
                                {
                                    val = strval[str];
                                    fnd2 = true;
                                    str2Arr[j] = val;
                                }

                                //Repeat for string 3
                                str = str3.Substring(str3.Length - 2, 1);
                                if (strval.ContainsKey(str))
                                {
                                    val = strval[str];
                                    fnd3 = true;
                                    str3Arr[i] = val;
                                }

                                Debug.WriteLine(str1Arr[k]);
                                Debug.WriteLine(str2Arr[j]);
                                Debug.WriteLine(str3Arr[i]);
                                Debug.WriteLine(k);
                                Debug.WriteLine(j);
                                Debug.WriteLine(i);
                                Debug.WriteLine(i);


                                //Decide which numbers to add or substract based on fixed numbers found
                                if (fnd1==true & fnd2==true & fnd3==false) //1 and 2 we know, third is sum of them
                                {
                                    str = str3.Substring(str3.Length - 2, 1); //Derive value for tenth digit in string 3
                                    sum = co+str1Arr[k] + str2Arr[j]; //include carryover from unit digit
                                    if (sum > 0)
                                    {
                                        if (sum > 9) //If value greater than 9, take the carryover to next digit place
                                        {
                                            val = sum % 10;
                                            co = sum / 10;
                                        }
                                        else //If single digit number, use the number as it is
                                        {
                                            val = sum;
                                            co = 0;
                                        }
                                    }
                                    else
                                    {
                                        Debug.WriteLine("Negative number to be handled");
                                    }
                                    str3Arr[i] = val;
                                    strval.Add(str, val); //Store the newly fixed key value pair in dictionary
                                    for (int x = 0; x <= leng; x++) //Check if chosen number is in random numbers array and replace with 0 to avoid use
                                    {
                                        if (inNum[x] == str3Arr[i])
                                        {
                                            inNum[x] = 0; // Set to zero to avoid same number used again
                                        }
                                    }
                                }
                                else
                                {
                                    if (fnd1==true & fnd2==false & fnd3==true)
                                    {
                                        str = str2.Substring(str2.Length - 2, 1); //Derive value for tenth digit in string 2
                                        sum = str3Arr[i] - str1Arr[k] - co; //Include carryover from unit digit
                                        if (sum < 0)
                                        {
                                            //Increase previous values by total 10, implemented above.
                                            Debug.WriteLine("Negative value to be handled");
                                        }
                                        else
                                        {
                                            if (sum > 9) //Split the double digit if value > 9
                                            {
                                                val = sum % 10;
                                                co = sum / 10;
                                            }
                                            else // If value <= 9, retain same value
                                            {
                                                val = sum;
                                                co = 0;
                                            }
                                        }
                                        str2Arr[j] = val;
                                        strval.Add(str, val); //Store the newly fixed key value pair in dictionary
                                        for (int x = 0; x <= leng; x++) //Check if chosen number is in random numbers array and replace with 0 to avoid use
                                        {
                                            if (inNum[x] == str2Arr[j])
                                            {
                                                inNum[x] = 0; // Set to zero to avoid same number used again
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (fnd1 == false & fnd2 == true & fnd3 == true)
                                        {
                                            str = str1.Substring(str1.Length - 2, 1); //Derive value for tenth digit in string 1
                                            sum = str3Arr[i] - str2Arr[j] - co; //Include carryover from unit digit
                                            if (sum > 0)
                                            {
                                                if (sum > 9) //If value greater than 9, take the carryover to next digit place
                                                {
                                                    val = sum % 10;
                                                    co = sum / 10;
                                                }
                                                else //If single digit number, use the number as it is
                                                {
                                                    val = sum;
                                                    co = 0;
                                                }
                                            }
                                            else
                                            {
                                                Debug.WriteLine("Negative number to be handled");
                                            }
                                            str1Arr[k] = val;
                                            strval.Add(str, val); //Store the newly fixed key value pair in dictionary
                                            for (int x = 0; x <= leng; x++) //Check if chosen number is in random numbers array and replace with 0 to avoid use
                                            {
                                                if (inNum[x] == str1Arr[k])
                                                {
                                                    inNum[x] = 0; // Set to zero to avoid same number used again
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (fnd1 == false & fnd2 == false & fnd3 == true)
                                            {
                                                strx1 = str1.Substring(str1.Length - 2, 1);//Derive tenth digit for string 1
                                                str = str2.Substring(str2.Length - 2, 1);
                                                for (int x=0;x<=leng;x++)
                                                {
                                                    if (inNum[x] > 0)
                                                    {
                                                        if (str3Arr[i] - co - inNum[x] > 0)
                                                        {
                                                            sum = str3Arr[i] - co - inNum[x]; //This is string 2 tenth digit value, as we are picking a random number for string 1 tenth digit
                                                            if (sum > 0)
                                                            {
                                                                if (sum > 9) //If value greater than 9, take the carryover to next digit place
                                                                {
                                                                    val = sum % 10;
                                                                    co = sum / 10;
                                                                }
                                                                else //If single digit number, use the number as it is
                                                                {
                                                                    val = sum;
                                                                    co = 0;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Debug.WriteLine("Negative number to be handled");
                                                            }
                                                            //val = sum % 10; //This val is for string 2
                                                            //co = sum / 10;
                                                            valx1 = inNum[x]; //This number is for string 1 Tenth place digit
                                                            fnd = true;
                                                            chosen = i;
                                                            inNum[x] = 0; //Set to 0 to avoid picking same number again
                                                            break;
                                                        }
                                                    }
                                                }
                                                if (fnd == false)
                                                {
                                                    sum = str3Arr[i] - co - 2; //Force any number for string 1 tenth digit, in this case 2
                                                    val = sum % 10; //This val is for string 2
                                                    co = sum / 10;
                                                    valx1 = 2; //Forced number for string 1 Tenth place digit
                                                }
                                                fnd = false;
                                                str1Arr[k] = valx1;
                                                strval.Add(strx1, valx1); //Store the newly fixed key value pair in dictionary for string 1
                                                str2Arr[j] = val;
                                                strval.Add(str, val); //Store the newly fixed key value pair in dictionary for string 2
                                                for (int x = 0; x <= leng; x++) //Check if chosen number is in random numbers array and replace with 0 to avoid use
                                                {
                                                    if (inNum[x] == str2Arr[j])
                                                    {
                                                        inNum[x] = 0; // Set to zero to avoid same number used again
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (fnd1 == false & fnd2 == true & fnd3 == false)
                                                {
                                                    strx1 = str1.Substring(str1.Length - 2, 1);
                                                    str = str3.Substring(str3.Length - 2, 1);
                                                    for (int x = 0; x <= leng; x++) //Choose a random number and assign to string 1 tenth place digit, avoid already chosen number above
                                                    {
                                                        if (inNum[x]>0)
                                                        {
                                                            sum = str2Arr[j] + co + inNum[x]; //String3=string1+string2 tenth place, string1 is forced
                                                            if (sum > 0)
                                                            {
                                                                if (sum > 9) //If value greater than 9, take the carryover to next digit place
                                                                {
                                                                    val = sum % 10;
                                                                    co = sum / 10;
                                                                }
                                                                else //If single digit number, use the number as it is
                                                                {
                                                                    val = sum;
                                                                    co = 0;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Debug.WriteLine("Negative number to be handled");
                                                            }
                                                            //val = sum % 10; //This val is for string 3
                                                            //co = sum / 10;
                                                            valx1 = inNum[x]; //This val is for string 1
                                                            fnd = true;
                                                            inNum[x] = 0; //Set value to 0 to avoid picking same number again
                                                            break;
                                                        }
                                                    }
                                                    if (fnd == false)
                                                    {
                                                        sum = str2Arr[j] + co + 1; //Force any number for string 1 tenth digit, in this case 1
                                                        val = sum % 10; //This val is for string 3
                                                        co = sum / 10;
                                                        valx1 = 1; //Forced number for string 1 Tenth place digit
                                                    }
                                                    fnd = false;
                                                    str1Arr[k] = valx1;
                                                    strval.Add(strx1, valx1); //Store the newly fixed key value pair in dictionary for string 1
                                                    str3Arr[i] = val;
                                                    strval.Add(str, val); //Store the newly fixed key value pair in dictionary for string 2
                                                    for (int x = 0; x <= leng; x++) //Check if chosen number is in random numbers array and replace with 0 to avoid use
                                                    {
                                                        if (inNum[x] == str3Arr[i])
                                                        {
                                                            inNum[x] = 0; // Set to zero to avoid same number used again
                                                            break;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    Debug.WriteLine("Consider this new case");
                                                }
                                                Debug.WriteLine(str1Arr[k]);
                                                Debug.WriteLine(str2Arr[j]);
                                                Debug.WriteLine(str3Arr[i]);
                                                Debug.WriteLine(k);
                                                Debug.WriteLine(j);
                                                Debug.WriteLine(i);
                                            }
                                        }

                                    }
                                }

                            }

                            //printvalues();

                            //100th Place, third digit from right
                            fnd = false; fnd1 = false; fnd2 = false; fnd3 = false;
                            if ((i == str3.Length - 3) & (j == str2.Length - 3) & (k == str1.Length - 3)) //Hundrendth digit in each string
                            {
                                //Check if the character in tenth digit has a set value, do it by dictionary lookup
                                str = str1.Substring(str1.Length - 3, 1);
                                if (strval.ContainsKey(str))
                                {
                                    val = strval[str];
                                    fnd1 = true;
                                    str1Arr[k] = val;
                                }

                                //Repeat for string 2
                                str = str2.Substring(str2.Length - 3, 1);
                                if (strval.ContainsKey(str))
                                {
                                    val = strval[str];
                                    fnd2 = true;
                                    str2Arr[j] = val;
                                }

                                //Repeat for string 3
                                str = str3.Substring(str3.Length - 3, 1);
                                if (strval.ContainsKey(str))
                                {
                                    val = strval[str];
                                    fnd3 = true;
                                    str3Arr[i] = val;
                                }

                                //Decide which numbers to add or substract based on fixed numbers found
                                if (fnd1 == true & fnd2 == true & fnd3 == false) //1 and 2 we know, third is sum of them
                                {
                                    str = str3.Substring(str3.Length - 3, 1); //Derive value for tenth digit in string 3
                                    sum = co + str1Arr[k] + str2Arr[j]; //include carryover from unit digit
                                    if (sum > 0)
                                    {
                                        if (sum > 9) //If value greater than 9, take the carryover to next digit place
                                        {
                                            val = sum % 10;
                                            co = sum / 10;
                                        }
                                        else //If single digit number, use the number as it is
                                        {
                                            val = sum;
                                            co = 0;
                                        }
                                    }
                                    else
                                    {
                                        Debug.WriteLine("Negative number to be handled");
                                    }
                                    //val = sum % 10;
                                    //co = sum / 10;
                                    str3Arr[i] = val;
                                    strval.Add(str, val); //Store the newly fixed key value pair in dictionary
                                    for (int x = 0; x <= leng; x++) //Check if chosen number is in random numbers array and replace with 0 to avoid use
                                    {
                                        if (inNum[x] == str3Arr[i])
                                        {
                                            inNum[x] = 0; // Set to zero to avoid same number used again
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    if (fnd1 == true & fnd2 == false & fnd3 == true)
                                    {
                                        str = str2.Substring(str2.Length - 3, 1); //Derive value for tenth digit in string 2
                                        sum = str3Arr[i] - str1Arr[k] - co; //Include carryover from unit digit
                                        if (sum > 0)
                                        {
                                            if (sum > 9) //If value greater than 9, take the carryover to next digit place
                                            {
                                                val = sum % 10;
                                                co = sum / 10;
                                            }
                                            else //If single digit number, use the number as it is
                                            {
                                                val = sum;
                                                co = 0;
                                            }
                                        }
                                        else
                                        {
                                            Debug.WriteLine("Negative number to be handled");
                                        }
                                        //val = sum % 10;
                                        //co = sum / 10;
                                        str2Arr[j] = val;
                                        strval.Add(str, val); //Store the newly fixed key value pair in dictionary
                                        for (int x = 0; x <= leng; x++) //Check if chosen number is in random numbers array and replace with 0 to avoid use
                                        {
                                            if (inNum[x] == str2Arr[j])
                                            {
                                                inNum[x] = 0; // Set to zero to avoid same number used again
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (fnd1 == false & fnd2 == true & fnd3 == true)
                                        {
                                            str = str1.Substring(str1.Length - 3, 1); //Derive value for tenth digit in string 1
                                            sum = str3Arr[i] - str2Arr[j] - co; //Include carryover from unit digit
                                            if (sum > 0)
                                            {
                                                if (sum > 9) //If value greater than 9, take the carryover to next digit place
                                                {
                                                    val = sum % 10;
                                                    co = sum / 10;
                                                }
                                                else //If single digit number, use the number as it is
                                                {
                                                    val = sum;
                                                    co = 0;
                                                }
                                            }
                                            else
                                            {
                                                Debug.WriteLine("Negative number to be handled");
                                            }
                                            //val = sum % 10;
                                            //co = sum / 10;
                                            str1Arr[k] = val;
                                            strval.Add(str, val); //Store the newly fixed key value pair in 
                                            for (int x = 0; x <= leng; x++) //Check if chosen number is in random numbers array and replace with 0 to avoid use
                                            {
                                                if (inNum[x] == str1Arr[k])
                                                {
                                                    inNum[x] = 0; // Set to zero to avoid same number used again
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (fnd1 == false & fnd2 == false & fnd3 == true)
                                            {
                                                strx1 = str1.Substring(str1.Length - 3, 1);//Derive tenth digit for string 1
                                                str = str2.Substring(str2.Length - 3, 1);
                                                for (int x = 0; x <= leng; x++)
                                                {
                                                    if (inNum[x] > 0)
                                                    {
                                                        if (str3Arr[i] - co - inNum[x] > 0)
                                                        {
                                                            sum = str3Arr[i] - co - inNum[x]; //This is string 2 tenth digit value, as we are picking a random number for string 1 tenth digit
                                                            val = sum % 10; //This val is for string 2
                                                            co = sum / 10;
                                                            valx1 = inNum[x]; //This number is for string 1 Tenth place digit
                                                            fnd = true;
                                                            chosen = i;
                                                            inNum[x] = 0; //Set to 0 to avoid picking same number again
                                                            break;
                                                        }
                                                    }
                                                }
                                                if (fnd == false)
                                                {
                                                    sum = str3Arr[i] - co - 2; //Force any number for string 1 tenth digit, in this case 2
                                                    val = sum % 10; //This val is for string 2
                                                    co = sum / 10;
                                                    valx1 = 2; //Forced number for string 1 Tenth place digit
                                                }
                                                fnd = false;
                                                str1Arr[k] = valx1;
                                                strval.Add(strx1, valx1); //Store the newly fixed key value pair in dictionary for string 1
                                                str2Arr[j] = val;
                                                strval.Add(str, val); //Store the newly fixed key value pair in dictionary for string 2
                                                for (int x = 0; x <= leng; x++) //Check if chosen number is in random numbers array and replace with 0 to avoid use
                                                {
                                                    if (inNum[x] == str2Arr[j])
                                                    {
                                                        inNum[x] = 0; // Set to zero to avoid same number used again
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (fnd1 == false & fnd2 == true & fnd3 == false)
                                                {
                                                    strx1 = str1.Substring(str1.Length - 3, 1);
                                                    str = str3.Substring(str3.Length - 3, 1);
                                                    for (int x = 0; x <= leng; x++) //Choose a random number and assign to string 1 tenth place digit, avoid already chosen number above
                                                    {
                                                        if (inNum[x]>0)
                                                        {
                                                            sum = str2Arr[j] + co + inNum[x]; //String3=string1+string2 tenth place, string1 is forced
                                                            if (sum > 0)
                                                            {
                                                                if (sum > 9) //If value greater than 9, take the carryover to next digit place
                                                                {
                                                                    val = sum % 10;
                                                                    co = sum / 10;
                                                                }
                                                                else //If single digit number, use the number as it is
                                                                {
                                                                    val = sum;
                                                                    co = 0;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Debug.WriteLine("Negative number to be handled");
                                                            }
                                                            //val = sum % 10; //This val is for string 3
                                                            //co = sum / 10;
                                                            valx1 = inNum[x]; //This val is for string 1
                                                            inNum[x] = 0; //Set value to 0 to avoid picking same number again
                                                            fnd = true;
                                                            break;
                                                        }
                                                    }
                                                    if (fnd == false)
                                                    {
                                                        sum = str2Arr[j] + co + 1; //Force any number for string 1 tenth digit, in this case 1
                                                        val = sum % 10; //This val is for string 3
                                                        co = sum / 10;
                                                        valx1 = 1; //Forced number for string 1 Tenth place digit
                                                    }
                                                    fnd = false;
                                                    str1Arr[k] = valx1;
                                                    strval.Add(strx1, valx1); //Store the newly fixed key value pair in dictionary for string 1
                                                    str3Arr[i] = val;
                                                    strval.Add(str, val); //Store the newly fixed key value pair in dictionary for string 2
                                                    for (int x = 0; x <= leng; x++) //Check if chosen number is in random numbers array and replace with 0 to avoid use
                                                    {
                                                        if (inNum[x] == str3Arr[i])
                                                        {
                                                            inNum[x] = 0; // Set to zero to avoid same number used again
                                                            break;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    Debug.WriteLine("Consider this new case");
                                                }
                                            }
                                        }

                                    }
                                }

                            }

                            //printvalues();

                            //1000th Place, fourth digit from right
                            fnd = false; fnd1 = false; fnd2 = false; fnd3 = false; fnd4=false;
                            if ((i == str3.Length - 4) & (j == str2.Length - 4) & (k == str1.Length - 4)) //Thousandth digit in each string
                            {
                                //Check if the character in 1000th digit has a set value, do it by dictionary lookup
                                str = str1.Substring(str1.Length - 4, 1);
                                if (strval.ContainsKey(str))
                                {
                                    val = strval[str];
                                    fnd1 = true;
                                    str1Arr[k] = val;
                                }

                                //Repeat for string 2
                                str = str2.Substring(str2.Length - 4, 1);
                                if (strval.ContainsKey(str))
                                {
                                    val = strval[str];
                                    fnd2 = true;
                                    str2Arr[j] = val;
                                }

                                //Repeat for string 3
                                str = str3.Substring(str3.Length - 4, 1);
                                if (strval.ContainsKey(str))
                                {
                                    val = strval[str];
                                    fnd3 = true;
                                    str3Arr[i] = val;
                                }

                                //Decide which numbers to add or substract based on fixed numbers found
                                if (fnd1 == true & fnd2 == true & fnd3 == false) //1 and 2 we know, third is sum of them
                                {
                                    str = str3.Substring(str3.Length - 4, 1); //Derive value for tenth digit in string 3
                                    sum = co + str1Arr[k] + str2Arr[j]; //include carryover from unit digit
                                    if (sum > 0)
                                    {
                                        if (sum > 9) //If value greater than 9, take the carryover to next digit place
                                        {
                                            val = sum % 10;
                                            co = sum / 10;
                                        }
                                        else //If single digit number, use the number as it is
                                        {
                                            val = sum;
                                            co = 0;
                                        }
                                    }
                                    else
                                    {
                                        Debug.WriteLine("Negative number to be handled");
                                    }
                                    //val = sum % 10;
                                    //co = sum / 10;
                                    str3Arr[i] = val;
                                    strval.Add(str, val); //Store the newly fixed key value pair in dictionary
                                    for (int x = 0; x <= leng; x++) //Check if chosen number is in random numbers array and replace with 0 to avoid use
                                    {
                                        if (inNum[x] == str3Arr[i])
                                        {
                                            inNum[x] = 0; // Set to zero to avoid same number used again
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    if (fnd1 == true & fnd2 == false & fnd3 == true)
                                    {
                                        str = str2.Substring(str2.Length - 4, 1); //Derive value for tenth digit in string 2
                                        sum = str3Arr[i] - str1Arr[k] - co; //Include carryover from unit digit
                                        if (sum > 0)
                                        {
                                            if (sum > 9) //If value greater than 9, take the carryover to next digit place
                                            {
                                                val = sum % 10;
                                                co = sum / 10;
                                            }
                                            else //If single digit number, use the number as it is
                                            {
                                                val = sum;
                                                co = 0;
                                            }
                                        }
                                        else
                                        {
                                            Debug.WriteLine("Negative number to be handled");
                                        }
                                        //val = sum % 10;
                                        //co = sum / 10;
                                        str2Arr[j] = val;
                                        strval.Add(str, val); //Store the newly fixed key value pair in dictionary
                                        for (int x = 0; x <= leng; x++) //Check if chosen number is in random numbers array and replace with 0 to avoid use
                                        {
                                            if (inNum[x] == str2Arr[j])
                                            {
                                                inNum[x] = 0; // Set to zero to avoid same number used again
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (fnd1 == false & fnd2 == true & fnd3 == true)
                                        {
                                            str = str1.Substring(str1.Length - 4, 1); //Derive value for tenth digit in string 1
                                            sum = str3Arr[i] - str2Arr[j] - co; //Include carryover from unit digit
                                            if (sum > 0)
                                            {
                                                if (sum > 9) //If value greater than 9, take the carryover to next digit place
                                                {
                                                    val = sum % 10;
                                                    co = sum / 10;
                                                }
                                                else //If single digit number, use the number as it is
                                                {
                                                    val = sum;
                                                    co = 0;
                                                }
                                            }
                                            else
                                            {
                                                Debug.WriteLine("Negative number to be handled");
                                            }
                                            //val = sum % 10;
                                            //co = sum / 10;
                                            str1Arr[k] = val;
                                            strval.Add(str, val); //Store the newly fixed key value pair in dictionary
                                            for (int x = 0; x <= leng; x++) //Check if chosen number is in random numbers array and replace with 0 to avoid use
                                            {
                                                if (inNum[x] == str1Arr[k])
                                                {
                                                    inNum[x] = 0; // Set to zero to avoid same number used again
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (fnd1 == false & fnd2 == false & fnd3 == true)
                                            {
                                                strx1 = str1.Substring(str1.Length - 4, 1);//Derive tenth digit for string 1
                                                str = str2.Substring(str2.Length - 4, 1);
                                                for (int x = 0; x <= leng; x++)
                                                {
                                                    if (inNum[x] > 0)
                                                    {
                                                        if (str3Arr[i] - co - inNum[x] > 0)
                                                        {
                                                            sum = str3Arr[i] - co - inNum[x]; //This is string 2 tenth digit value, as we are picking a random number for string 1 tenth digit
                                                            if (sum > 0)
                                                            {
                                                                if (sum > 9) //If value greater than 9, take the carryover to next digit place
                                                                {
                                                                    val = sum % 10;
                                                                    co = sum / 10;
                                                                }
                                                                else //If single digit number, use the number as it is
                                                                {
                                                                    val = sum;
                                                                    co = 0;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Debug.WriteLine("Negative number to be handled");
                                                            }
                                                            //val = sum % 10; //This val is for string 2
                                                            //co = sum / 10;
                                                            valx1 = inNum[x]; //This number is for string 1 Tenth place digit
                                                            fnd = true;
                                                            chosen = i;
                                                            inNum[x] = 0; //Set value to 0 to avoid picking same number again
                                                            break;
                                                        }
                                                    }
                                                }
                                                if (fnd == false)
                                                {
                                                    sum = str3Arr[i] - co - 2; //Force any number for string 1 tenth digit, in this case 2
                                                    val = sum % 10; //This val is for string 2
                                                    co = sum / 10;
                                                    valx1 = 2; //Forced number for string 1 Tenth place digit
                                                }
                                                fnd = false;
                                                str1Arr[k] = valx1;
                                                strval.Add(strx1, valx1); //Store the newly fixed key value pair in dictionary for string 1
                                                str2Arr[j] = val;
                                                strval.Add(str, val); //Store the newly fixed key value pair in dictionary for string 2
                                                for (int x = 0; x <= leng; x++) //Check if chosen number is in random numbers array and replace with 0 to avoid use
                                                {
                                                    if (inNum[x] == str2Arr[j])
                                                    {
                                                        inNum[x] = 0; // Set to zero to avoid same number used again
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (fnd1 == false & fnd2 == true & fnd3 == false)
                                                {
                                                    strx1 = str1.Substring(str1.Length - 4, 1);
                                                    str = str3.Substring(str3.Length - 4, 1);
                                                    for (int x = 0; x <= leng; x++) //Choose a random number and assign to string 1 tenth place digit, avoid already chosen number above
                                                    {
                                                        if (inNum[x]>0)
                                                        {
                                                            //sum = str2Arr[j] + co + inNum[x]; //String3=string1+string2 tenth place, string1 is forced
                                                            //Change this part... choose two random numbers. One for sum as well to satisfy co+U+C = U*10+N. Choose N first and decide U. Replace C and N with numbers to get this condition satisfied.
                                                            //Let inNum[x] selected be N. Then U would be (co+C-N)/9
                                                            sum = co + str2Arr[j] - inNum[x]; //inNum[x] is the value of third string first letter
                                                            if (sum%9==0)
                                                            {
                                                                fnd4 = true;
                                                                val = sum/9; //This is 10000th place for string 1 (first letter value)
                                                                valx1 = inNum[x]; //This val is for string 3
                                                            }
                                                            else
                                                            {
                                                                //find a number in inNum[x] that makes co + str2Arr[j] - inNum[x] divisible by 9 (sum of digits divisible by 9)
                                                                if (9-(co + str2Arr[j] - inNum[x])>0)
                                                                {
                                                                    
                                                                    val = (co + str2Arr[j] - inNum[x]) + (9 - (co + str2Arr[j] - inNum[x]));//Val for string 3
                                                                    valx1 = 9; //This val is for string 1, it is 9
                                                                    fnd4 = true;
                                                                }
                                                                else
                                                                {
                                                                    if (18 - (co + str2Arr[j] - inNum[x]) > 0)
                                                                    {
                                                                        
                                                                        val = (co + str2Arr[j] - inNum[x]) + (18 - (co + str2Arr[j] - inNum[x]));
                                                                        valx1 = 18; //This val is for string 1, it is 18
                                                                        fnd4 = true;
                                                                    }
                                                                }

                                                            }

                                                            
                                                            //val = sum % 10; //This val is for string 3
                                                            //co = sum / 10;
                                                            //valx1 = inNum[x]; //This val is for string 1
                                                            //fnd = true;
                                                            //inNum[x] = 0;//Set value to 0 to avoid picking same number again
                                                            break;
                                                        }
                                                    }
                                                    if (fnd4 == false)
                                                    {
                                                        //sum = str2Arr[j] + co + 1; //Force any number for string 1 tenth digit, in this case 1
                                                        //val = sum % 10; //This val is for string 3
                                                        //co = sum / 10;
                                                        //valx1 = 1; //Forced number for string 1 Tenth place digit
                                                    }
                                                    fnd = false;
                                                    fnd4 = false;
                                                    str1Arr[k] = val;
                                                    strval.Add(strx1, val); //Store the newly fixed key value pair in dictionary for string 1
                                                    str3Arr[i] = valx1;
                                                    strval.Add(str, valx1); //Store the newly fixed key value pair in dictionary for string 2
                                                    

                                                }
                                                else
                                                {
                                                    Debug.WriteLine("Consider this new case");
                                                }
                                            }
                                        }

                                    }
                                }

                            }
                            //
                        }
                    }
                }
                printvalues();

                void printvalues ()
                {
                    for (int i = 0; i < str1.Length; i++)
                    {
                        Debug.WriteLine(str1Arr[i]);
                        //Debug.WriteLine(str2Arr[i]);
                    }
                    Debug.WriteLine("............");
                    for (int i = 0; i < str1.Length; i++)
                    {
                        //Debug.WriteLine(str1Arr[i]);
                        Debug.WriteLine(str2Arr[i]);
                    }
                    Debug.WriteLine("______");
                    for (int i = 0; i < str3.Length; i++)
                    {
                        Debug.WriteLine(str3Arr[i]);
                    }
                    Debug.WriteLine("+++++++++++++");
                }
                //Learings and Recommendations




            }

            catch
            {
                Console.WriteLine("Exception occurred while computing solvePuzzle()");
            }

        }

    }
}
