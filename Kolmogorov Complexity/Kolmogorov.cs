using System;

namespace KolmogorovComplexity
{
    public class Kolmogorov
    {
        public static int GetComplexity(string inputBinarySequence)
        {
            if (string.IsNullOrEmpty(inputBinarySequence))
            {
                return -1;
            }

            var n = inputBinarySequence.Length;
            var complexity = 1;
            var l = 1;
            var i = 0;
            var k = 0;
            var kMax = 1;
            var stop = 0;

            while (stop == 0)
            {
                if (inputBinarySequence[i + k] != inputBinarySequence[l + k])
                {
                    if (k > kMax)
                    {
                        kMax = k;
                    }

                    i++;

                    if (i == l)
                    {
                        complexity++;
                        l += kMax;

                        if (l + 1 >= n)
                        {
                            stop = 1;
                        }
                        else
                        {
                            i = 0;
                            k = 1;
                            kMax = 1;
                        }
                    }
                    else
                    {
                        k = 1;
                    }
                }
                else
                {
                    k++;
                    if (l + k >= n)
                    {
                        complexity++;
                        stop = 1;
                    }
                }
            }

            return complexity;
        }

        public static double ConvertToNormalizedComplexity(int complexity, int messageLength)
        {
            return complexity / (messageLength / Math.Log(messageLength, 2));
        }
    }
}
