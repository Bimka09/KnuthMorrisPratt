namespace KnuthMorrisPrattAlgorithm
{
    public class KMP
    {
        int[] pi;
        public void SlowPi(string text)
        {
            pi = new int[text.Length + 1]; 
            for (int q = 0; q <= text.Length; q++)
            {
                var line = text.Substring(0, q);
                var lineL = line.Length;
                for (int len = 0; len < q; len++)
                {
                    if(line.Substring(0, len) == line.Substring(lineL - len))
                    {
                        pi[q] = len;
                    }
                }
            }
        }

        public void FastPi(string text)
        {
            pi = new int[text.Length + 1];
            pi[1] = 0;
            for (int q = 1; q < text.Length; q++)
            {
                int len = pi[q];
                while(len > 0 && text[len] != text[q])
                {
                    len = pi[len];
                }
                if(text[len] == text[q])
                {
                    len++;
                }
                pi[q + 1] = len;
            }
        }

        public List<int> SearchEntry(string text, string pattern)
        {
            var kmp = new KMP();
            var foundIndexes = new List<int>();
            kmp.FastPi(pattern + "#" + text);
            var resultPi = kmp.pi;
            var patternLength = pattern.Length;
            for(int i = resultPi.Length - 1; i > 0; i--)
            {
                if(resultPi[i] == patternLength)
                {
                    foundIndexes.Add(i - patternLength * 2);
                }
            }
            return foundIndexes;
        }
    }
}
