using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();


        }

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int first = 0;
                int last = nums.Length - 1;
                int output = -1;
                while (first <= last)
                {
                    // getting the middle number
                    int mid = (first + last) / 2;

                    if (nums[mid] == target)
                    {
                        // if condition satisfies
                        return mid;
                    }
                    if (nums[mid] > target)
                    {
                        last = mid - 1;
                        output = mid;
                    }
                    else
                    {
                        first = mid + 1;
                        output = mid + 1;
                    }
                }

                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                //write your code here.
                // converting all the words into lower case
                paragraph = paragraph.ToLower();
                //replacing special characters with space
                paragraph = paragraph.Replace(',', ' ');
                paragraph = paragraph.Replace('.', ' ');
                // removing the xtra spaces
                paragraph = paragraph.Trim();
                Console.WriteLine(paragraph);
                // splitting the input 
                string[] ipsplit = paragraph.Split(' ');
                int length = ipsplit.Length;
                // using dictionary for getting kvp
                IDictionary<string, int> count = new Dictionary<string, int>();
                for (int i = 0; i < length; i++)
                {

                    if (count.ContainsKey(ipsplit[i]))
                    {
                        // increasing the count if the word repeats
                        count[ipsplit[i]]++;
                    }
                    else
                    {
                        // adding the new word
                        count.Add(ipsplit[i], 1);
                    }
                    for (int j = 0; j < banned.Length; j++)
                    {
                        if (ipsplit[i] == banned[j])
                        {
                            //removing the banned word
                            count.Remove(ipsplit[i]);
                        }
                    }
                }
                int max = 0;
                string maxKey = "";
                foreach (KeyValuePair<string, int> kvp in count)
                {
                    if (max < kvp.Value)
                    {
                        // getting the key using value
                        max = kvp.Value;
                        maxKey = kvp.Key;
                    }
                }
                return maxKey;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int FindLucky(int[] arr)
        {
            try
            {
                //write your code here.
                IDictionary<int, int> count = new Dictionary<int, int>();
                for (int i = 0; i < arr.Length; i++)
                {
                    // increasing the count to know the number of same int in the array
                    if (count.ContainsKey(arr[i]))
                    {
                        count[arr[i]]++;
                    }
                    // adds the new number
                    else
                    {
                        count.Add(arr[i], 1);
                    }
                }
                int max = 0;
                foreach (KeyValuePair<int, int> kvp in count)
                {
                    // checking the number is repeated as many times as the number
                    if (kvp.Key == kvp.Value)
                    {
                        // getting the max number
                        if (max < kvp.Key)
                        {
                            max = kvp.Key;
                        }
                    }
                }
                return max;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static string GetHint(string secret, string guess)
        {
            try
            {
                //write your code here.
                int count = 0;
                int sum = 0;
                string s = "";
                string t = "";
                for (int j = 0; j < guess.Length; j++)
                {
                    if (secret[j] == guess[j])
                    {
                        // increasing the count if the above condition satisfies
                        count = count + 1;
                    }
                    else
                    {
                        // adding the elements to the string
                        s = s + secret[j];
                        t = t + guess[j];
                    }
                }
                foreach (char c in s)
                {
                    int flag = 0;
                    for (int i = 0; i < t.Length; i++)
                    {
                        if (t[i] == c && flag == 0)
                        {
                            sum = sum + 1;
                            t = t.Remove(i, 1);
                            flag = 1;
                        }
                    }
                }
                string z = count.ToString() + "A" + sum.ToString() + "B";
                return z;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                // write your code here.
                int l = s.Length;
                List<int> output = new List<int>();
                int[] a = new int[26];
                for (int i = l - 1; i >= 0; i--)
                {
                    if (a[s[i] - 97] == 0)
                    {
                        a[s[i] - 97] = i;
                    }
                }
                int index = 0;
                while (index < l)
                {
                    int min = index;
                    int max = a[s[index] - 97];
                    int diff = max - min + 1;
                    for (int k = min; k <= max; k++)
                    {
                        //checks the condition and enters the loop
                        if (a[s[k] - 97] > max)
                        {
                            max = a[s[k] - 97];
                            diff = max - min + 1;
                        }

                    }
                    output.Add(diff);
                    index = max + 1;
                }
                //printing the final output
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                //write your code here.
                int sum = 0;
                int n = 0;
                int count = 1;

                for (int i = 0; i < s.Length; i++)
                {
                    n = widths[s[i] - 97];
                    sum = sum + n;
                    if (sum > 100)
                    {
                        // assigning the n value to s
                        sum = n;
                        // incrementing the count by 1
                        count = count + 1;
                    }
                }
                List<int> output = new List<int>();
                output.Add(count);
                output.Add(sum);
                return output;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                int l = bulls_string10.Length;
                ArrayList arr = new ArrayList();
                Dictionary<string, string> def = new Dictionary<string, string>();
                def.Add("}", "{");
                def.Add("]", "[");
                def.Add(")", "(");
                int count = -1;
                for (int i = 0; i < l; i++)
                {
                    string a = bulls_string10[i].ToString();
                    if (def.ContainsValue(a))
                    {
                        arr.Add(a);
                        // size of the arraylist
                        count = count + 1;
                    }
                    else if (def.ContainsKey(a) & count != -1)
                    {
                        if (def[a] == arr[count].ToString())
                        {
                            arr.RemoveAt(count);
                            count = count - 1;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (count == -1)
                    {
                        return false;
                    }
                }
                if (count != -1)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                //write your code here.
                string[] check = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                int wl = words.Length;
                string[] final = new string[wl];
                for (int i = 0; i < wl; i++)
                {
                    string s = words[i];
                    int sl = s.Length;
                    string p = "";
                    for (int j = 0; j < sl; j++)
                    {
                        int n = s[j] - 97;
                        p = p + check[n];
                    }
                    final[i] = p;
                }
                // gives the count of unique
                int count = final.Distinct().Count();
                return count;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}


