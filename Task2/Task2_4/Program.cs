﻿using System;

namespace Task2_4
{
	class Program
	{
		static void Main(string[] args)
		{
			char[] array1 = { 'a', 'b', 'c', 'd' };
			char[] array2 = { 'a', 'b', 'c', 'e', 'f' };
			MyString myString1 = new MyString(array1);
			MyString myString2 = new MyString(array2);
			Console.WriteLine("First line: {0}", myString1);
			Console.WriteLine("Second line: {0}", myString2);
			Console.WriteLine("Line Equality: {0}", myString1 == myString2);
			Console.WriteLine("The third element in the first line: {0}", myString1[2]);
			Console.WriteLine("The first line is larger than the second line: {0}", myString1 > myString2);
		}
	}

	class MyString
	{
		private char[] str;
		/// <summary>
		/// String length
		/// </summary>
		public int Length { get => str.Length; }
		public MyString()
		{
			str = new char[0];
		}
		public MyString(char[] charArray)
		{
			str = charArray;
		}
		public char this[int index]
		{
			get => str[index];
			set => str[index] = value;
		}
		public static bool operator >(MyString str1, MyString str2) => str1.Length > str2.Length;
		public static bool operator <(MyString str1, MyString str2) => str1.Length < str2.Length;
		public static bool operator ==(MyString str1, MyString str2)
		{
			if (str1.Length != str2.Length)
				return false;
			for (int i = 0; i < str1.Length; i++)
				if (str1[i] != str2[i])
					return false;
			return true;
		}
		public static bool operator !=(MyString str1, MyString str2)
		{
			if (str1.Length != str2.Length)
				return true;
			for (int i = 0; i < str1.Length; i++)
				if (str1[i] != str2[i])
					return true;
			return false;
		}
		public static MyString operator +(MyString str1, MyString str2)
		{
			MyString newStr = new MyString();
			newStr.str = new char[str1.Length + str2.Length];
			str1.str.CopyTo(newStr.str, 0);
			str2.str.CopyTo(newStr.str, str1.Length);
			return newStr;
		}
		/// <summary>
		/// Translate MyString to char array
		/// </summary>
		/// <returns>Массив char</returns>
		public char[] ToCharArray() => str;
		/// <summary>
		/// Returns the index of the first occurrence of a symbol in a string.
		/// </summary>
		/// <param name="symbol">Search character</param>
		/// <returns>Index of occurrence</returns>
		public int Find(char symbol)
		{
			for (int i = 0; i < str.Length; i++)
				if (str[i] == symbol)
					return i;
			return -1;
		}
		public override string ToString() => new string(str);
	}
}
