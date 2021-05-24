using System;
using System.Collections.Generic;
using System.Numerics;

namespace RSA
{
	class alphabetList
	{
		public char Symbol { get; set; }
		public int Frequency { get; set; }

        public static BigInteger[] GetAlpabetIndex(string message)
        {
            message = message.ToLower();
            char[] ukr = new char[] { 'а', 'б', 'в', 'г', 'ґ', 'д', 'е', 'є', 'ж', 'з', 'и', 'і', 'ї', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш',
                'щ', 'ь', 'ю', 'я', '_', ' ', '?', ',', '.', '!' };
            BigInteger[] num = new BigInteger[Convert.ToUInt64(message.Length)];

            for (int i = 0; i < message.Length; i++)
            {
                for (ulong j = 0; j < (ulong)ukr.Length; j++)
                {
                    if (message[i] == ukr[j])
                    {
                        num[i] = j;
                        break;
                    }
                }
            }
            return num;
        }
    }
}
