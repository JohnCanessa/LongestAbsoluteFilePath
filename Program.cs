using System;
using System.Collections.Generic;


namespace LongestAbsoluteFilePathCSharp
{
    internal class Program
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int LengthLongestPath(String input)
        {

            // **** initialization ****
            int maxLen          = 0;
            Stack<int> stack    = new Stack<int>();
            stack.Push(maxLen);

            // ???? ????
            Console.WriteLine("LengthLongestPath <<< input ==>{0}<==", input);

            // **** ****
            foreach (var p in input.Split('\n')) {

                // ???? ????
                Console.WriteLine("LengthLongestPath <<< p ==>{0}<==", p);

                // **** compute the path level ****
                var level = p.LastIndexOf('\t');
                level++;

                // ???? ????
                Console.WriteLine("LengthLongestPath <<< level: {0}", level);

                // **** compute the length of this path ****
                var length = p.Length;
                length -= level;

                // ???? ????
                Console.WriteLine("LengthLongestPath <<< length: {0}", length);

                // **** adjust the stack (if needed) ****
                while (stack.Count > level + 1)
                {
                    var popped = stack.Pop();

                    // ???? ????
                    Console.WriteLine("LengthLongestPath <<< popped: {0}", popped);
                }

                // ???? very cumbersome ????
                Console.Write("LengthLongestPath <<< stack: ");
                foreach (var se in stack)
                    Console.Write("{0} ", se);
                Console.WriteLine();

                // **** p is a file ****
                if (p.Contains("."))
                {
                    maxLen = Math.Max(maxLen, stack.Peek() + length);

                    // ???? ????
                    Console.WriteLine("LengthLongestPath <<< maxLen: {0}", maxLen);
                }

                // **** p is a directory ****
                else
                {
                    stack.Push(stack.Peek() + length + 1);

                    // ???? very cumbersome ????
                    Console.Write("LengthLongestPath <<< stack: ");
                    foreach (var se in stack)
                        Console.Write("{0} ", se);
                    Console.WriteLine();
                }
            }

            // **** return max length ****
            return maxLen;
        }


        /// <summary>
        /// Test scaffold.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            // **** test cases ****
            String[] testCases = new String[4];
            testCases[0] = "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext";
            testCases[1] = "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext";
            testCases[2] = "a";
            testCases[3] = "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext";

            // **** run all test cases ****
            foreach (String testCase in testCases)
            {

                // **** compute result ****
                var maxLen = LengthLongestPath(testCase);

                // **** display result ****
                Console.WriteLine("Main <<< maxLen: {0}\n", maxLen);
            }

            // ???? ????
            Console.Write("Main >>> press <Enter> to exit: ");
            Console.ReadLine();
        }
    }
}
