using System;

namespace RandomPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetRandomPassword(2, 8, true, true));
            Console.WriteLine(GetRandomPassword(5, 8, true, false));
        }
        static string GetRandomPassword(int minLength, int maxLength, bool includeLetters, bool includeNumbers)
        {
            if (maxLength < minLength)
            {
                throw new ArgumentException($"{nameof(minLength)} cant be greater than {nameof(maxLength)}.");
            }
            if (minLength == 0 && maxLength == 0)
            {
                throw new ArgumentException("We can't generate password with zero length!");
            }
            if (!includeLetters && !includeNumbers)
            {
                throw new ArgumentException("Password must include numbers and letters!");
            }

            Random r = new Random();
            int index = r.Next(minLength, maxLength);
            string result = "";

            for (int i = 0; i < index; i++)
            {
                if (includeNumbers && includeLetters)
                {
                    result += r.Next(10);
                    int num = r.Next(0, 25);
                    result += (char)('a' + num);
                    i++;
                }
                else if (includeNumbers)
                {
                    result += r.Next(10);
                }
                else
                {
                    result += (char)('a' + r.Next(0, 26));
                }

            }
            return result;
        }
    }
}
