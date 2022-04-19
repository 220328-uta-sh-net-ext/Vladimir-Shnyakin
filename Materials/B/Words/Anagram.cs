namespace Words
{
    public class Anagrams
    {
        public static bool Anagram(string s1, string s2)
        {
            s1=s1.ToLower();
            s2=s2.ToLower();
            if (s1.Length != s2.Length)
                return false;
            int countChars = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                char current = s1[i];
                for (int j = 0; j < s2.Length; j++)
                {
                    if (current == s2[j])
                    {
                        countChars++;
                        break;
                        //Console.WriteLine(countChars);
                    }
                }
            }
            Console.WriteLine(countChars);
            if (countChars == s1.Length)
                return true;
            else
                return false;

        }
        //  If (int count = s1.Count(f => f == s1[i]))

        // Console.WriteLine("Not an anagram!");

    }
}