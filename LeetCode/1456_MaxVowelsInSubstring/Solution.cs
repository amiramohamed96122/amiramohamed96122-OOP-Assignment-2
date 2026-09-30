public class Solution
{
    public int MaxVowels(string s, int k)
    {
        int count = 0;

        // Count vowels in the first window
        for (int i = 0; i < k; i++)
        {
            if (IsVowel(s[i]))
            {
                count++;
            }
        }

        int maxVowels = count;

        // Slide the window
        for (int i = k; i < s.Length; i++)
        {
            // Character leaving the window
            if (IsVowel(s[i - k]))
            {
                count--;
            }

            // Character entering the window
            if (IsVowel(s[i]))
            {
                count++;
            }

            maxVowels = Math.Max(maxVowels, count);
        }

        return maxVowels;
    }

    private bool IsVowel(char c)
    {
        return c == 'a' ||
               c == 'e' ||
               c == 'i' ||
               c == 'o' ||
               c == 'u';
    }
}
