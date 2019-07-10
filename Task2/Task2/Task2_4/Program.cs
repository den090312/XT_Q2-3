using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_4
{
	class Program
	{
		static void Main(string[] args)
		{
		}
	}

	class MyString
	{
		public char[] Str { private set; get; }

		public int Length { get => Str.Length; }

		public static bool operator > (MyString str1, MyString str2) => str1.Length > str2.Length;
		public static bool operator < (MyString str1, MyString str2) => str1.Length < str2.Length;
		public static MyString operator + (MyString str1, MyString str2)
		{
			MyString newStr = new MyString();
			newStr.Str = new char[str1.Length + str2.Length];
			str1.Str.CopyTo(newStr.Str, 0);
			str2.Str.CopyTo(newStr.Str, str1.Length);
			return newStr;
		}

	}
}
