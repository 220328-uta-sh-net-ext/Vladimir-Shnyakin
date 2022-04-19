namespace Words
{
    public class Palindromes
    {
        public static bool Palindrome(string s)
        {
            s=s.ToLower();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != s[s.Length - i-1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}