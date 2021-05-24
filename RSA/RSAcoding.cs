using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
namespace RSA
{
	class Program
	{
		static void Main(string[] args)
		{		
			Console.OutputEncoding = System.Text.Encoding.Unicode;
			Console.InputEncoding = System.Text.Encoding.Unicode;
			Console.WriteLine("Ведіть повідомлення");
			string message = Console.ReadLine();
			BigInteger[] alpabetindexes = alphabetList.GetAlpabetIndex(message);
			for (int i = 0; i < alpabetindexes.Length; i++)		
				Console.Write(alpabetindexes[i] + " ");			
    		Console.WriteLine();
			BigInteger p = 0;
			BigInteger q = 0;
			while (true)
			{
				Console.WriteLine("Ведіть: p");
				p = Convert.ToUInt64(Console.ReadLine());
				Console.WriteLine("Ведіть: q");
				q = Convert.ToUInt64(Console.ReadLine());
				if (p > 1 & q > 1) break;
				else { Console.WriteLine("p і q повинні буди більше 1"); }
			}
			BigInteger modul = p * q;	
			BigInteger f = (p - 1) * (q - 1);
			Console.WriteLine("Ведіть е");
			BigInteger e = Convert.ToUInt64(Console.ReadLine()); //відкрита експонента
			BigInteger d = GetCoplime(e, f);
			BigInteger[] Encoded = Encode(alpabetindexes, e, modul);
			print(Encoded);
			BigInteger[] Decoded = Decode(Encoded, d, modul);
			print(Decoded);
		}
		public static void print(BigInteger[] arrey)
		{
			for (int i = 0; i < arrey.Length; i++)		
				Console.Write(arrey[i] + " ");	
			Console.WriteLine();
		}
		public static BigInteger[] Decode(BigInteger[] encoded, BigInteger d, BigInteger n)
		{
			BigInteger[] decoded = new BigInteger[encoded.Length];
			string zcycle = Convert.ToString((int)d,  2);
			for (int i = 0; i < encoded.Length; i++)
			{
				decoded[i] = encoded[i];
				for (int j = 1; j < zcycle.Length; j++)
				{
					if (zcycle[j] == '0') decoded[i] = (decoded[i] * decoded[i]) % n;
					if (zcycle[j] == '1') decoded[i] = (decoded[i] * decoded[i] * encoded[i]) % n;
				}
			}
			return decoded;
		}
		public static BigInteger[] Encode(BigInteger[] num, BigInteger e, BigInteger modul)
		{
			BigInteger[] encrypted = new BigInteger[num.Length];
			string zcycle = Convert.ToString((int)e, 2);
			Console.WriteLine("Encoded: ");
			for (int i = 0; i < num.Length; i++)
			{
				encrypted[i] = num[i];
				for (int j = 1; j < zcycle.Length; j++)
				{
					if (zcycle[j] == '0')
						encrypted[i] = (encrypted[i] * encrypted[i]) % modul;
					if (zcycle[j] == '1')
						encrypted[i] = (encrypted[i] * encrypted[i] * num[i]) % modul;
				}			
			}
			return encrypted;
		}
		public static BigInteger GetCoplime(BigInteger e, BigInteger f)
		{
			BigInteger d = 0;
			while ((d * e) % f != 1)
			{
				d++;
				if (d > f)
				{
					Console.WriteLine("No Coplimes found!");
				}
			}
			return d;
		}
	}
}
