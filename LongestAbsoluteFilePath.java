import java.io.IOException;
import java.util.Stack;


/**
 * Note from Omegang on August 19, 2022
 * 
 * This is not my answer.
 * I found it in this Github repository: https://github.com/AnasImloul/Leetcode-solutions/.
 * It has solutions to almost every problem on Leetcode, and I recommend checking it out.
 */
public class LongestAbsoluteFilePath{


    /**
     * Longest Absolute File Path.
     * Execution: O(n) - Space: O(n)
     * @param input
     * @return
    */
    static int lengthLongestPath(String input) {
        
        // **** initialization ****
        int maxLen              = 0;
        Stack<Integer> stack    = new Stack<Integer>();
        stack.push(maxLen);

        // ???? ????
        System.out.println("lengthLongestPath <<< input ==>" + input + "<==");

        // **** loop once per path (a path could be a directory or a file) ****
        for (String p : input.split("\n")) {

            // ???? ????
            System.out.println("lengthLongestPath <<< p ==>" + p + "<==");

            // **** compute the path level ****
            int level = p.lastIndexOf("\t");
            level++;

            // ???? ????
            System.out.println("lengthLongestPath <<< level: " + level);

            // **** compute the length of this path ****
            int length = p.length();
            length -= level;

            // ???? ????
            System.out.println("lengthLongestPath <<< length: " + length);

            // **** adjust the stack (if needed) ****
            while (stack.size() > level + 1) {

                // **** ****
                int popped = stack.pop();

                // ???? ?????
                System.out.println("lengthLongestPath <<< popped: " + popped);
            }

            // ???? ????
            System.out.println("lengthLongestPath <<< stack: " + stack.toString());

            // **** p is a file ****
            if (p.contains(".")) {

                // **** max length including this path ****
                maxLen = Math.max(maxLen, stack.peek() + length);

                // ???? ????
                System.out.println("lengthLongestPath <<< maxLen: " + maxLen);
            }

            // **** p is a directory ****
            else {

                // **** save it's length + '/' ****
                stack.push(stack.peek() + length + 1);

                // ???? ????
                System.out.println("lengthLongestPath <<< stack: " + stack.toString());
            }
        }

        // **** return the length of the max path of a file ****
        return maxLen;
    }


    /**
     * Test scaffold.
     * @throws IOException
     */
    public static void main(String[] args) throws IOException {

        // **** initialization ****
        int n = 4;

        // **** populate array of test cases ****
        String[] testCases = new String[4];
        testCases[0] = "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext";
        testCases[1] = "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext";
        testCases[2] = "a";
        testCases[3] = "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext";

        // **** run all test cases ****
        for (String testCase : testCases) {

            // **** compute the max length ****
            int maxLen = lengthLongestPath(testCase);

            // **** display the max length ****
            System.out.println("main <<< maxLen: " + maxLen + "\n");
        }
    }
}