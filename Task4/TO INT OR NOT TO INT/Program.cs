using System;

namespace TO_INT_OR_NOT_TO_INT
{
	class Program
	{
		static void Main(string[] args)
		{
			string str1 = "-33444";
			string str2 = "555";
			string str3 = "abc";
			Console.WriteLine("Is {0} digit: {1}", str1, str1.IsNumber());
			Console.WriteLine("Is {0} digit: {1}", str2, str2.IsNumber());
			Console.WriteLine("Is {0} digit: {1}", str3, str3.IsNumber());
		}
	}

	static class StringExtension
	{
		public static bool IsNumber(this string str)
		{
			if (str.Length > 1)
			{
				//minus check
				if (!char.IsDigit(str[0]) && str[0] != '-')
					return false;
				//digit check
				for (int i = 1; i < str.Length; i++)
				{
					if (!char.IsDigit(str[i]))
						return false;
				}
			} //digit check
			else if (str.Length == 1)
			{
				if (!char.IsDigit(str[0]))
				{
					return false;
				}
			}
			//str is number
			return true;
		}
	}
}
