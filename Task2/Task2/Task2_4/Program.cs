using System;

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
			Console.WriteLine("Первая строка: {0}", myString1);
			Console.WriteLine("Вторая строка: {0}", myString2);
			Console.WriteLine("Равенство строк: {0}", myString1 == myString2);
			Console.WriteLine("Третий элемент в первой строке: {0}", myString1[2]);
			Console.WriteLine("Первая строка больше чем вторая строка: {0}", myString1 > myString2);
		}
	}

	class MyString
	{
		private char[] str;
		/// <summary>
		/// Длина строки
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
		/// Переводит MyString в массив char
		/// </summary>
		/// <returns>Массив char</returns>
		public char[] ToCharArray() => str;
		/// <summary>
		/// Возвращает индекс первого вхождения символа symbol в строке
		/// </summary>
		/// <param name="symbol">Символ для поиска</param>
		/// <returns>Индекс вхождения</returns>
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
