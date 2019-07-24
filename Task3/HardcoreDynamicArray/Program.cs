using DYNAMIC_ARRAY;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Hardcore_Dynamic_Array
{
	public class HardcoreDynamicArray<T> : DynamicArray<T>, ICloneable
	{
		/// <summary>
		/// Индексатор с возможностью идти с конца с помощью отрицательных чисел
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public new T this[int index]
		{
			get
			{
				if (index >= 0 && index < Length)
					return array[index];
				else if (index < 0 && Math.Abs(index) < Length)
					return array[Length + index];
				else throw new ArgumentOutOfRangeException("Wrong argument: index cannot be greater then array length or negative.");
			}
			set
			{
				if (index < Length || index < 0)
					array[index] = value;
				else throw new ArgumentOutOfRangeException("Wrong argument: index cannot be greater then array length or negative.");
			}
		}

		public new int Capacity
		{
			get => array.Length;
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("Wrong argument: capacity cannot be negative");
				else
				{
					var temp = new T[value];
					int newLength = (value > Length) ? Length : value;
					Array.Copy(array, temp, newLength);
					array = temp;
					Length = newLength;
				}
			}
		}

		public HardcoreDynamicArray() : base()
		{

		}

		public HardcoreDynamicArray(int capacity) : base(capacity)
		{

		}

		public HardcoreDynamicArray(IEnumerable<T> ts) : base(ts)
		{

		}

		public object Clone()
		{
			return MemberwiseClone();
		}

		public T[] ToArray()
		{
			T[] buff = new T[Length];
			Array.Copy(array, 0, buff, 0, Length);
			return buff;
		}
	}

	class CycledArray<T> : DynamicArray<T>, IEnumerable<T>
	{
		public CycledArray() : base()
		{

		}

		public CycledArray(int capacity) : base(capacity)
		{

		}

		public CycledArray(IEnumerable<T> ts) : base(ts)
		{

		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			T[] newArray = new T[Length];
			Array.Copy(array, newArray, Length);
			return new CycledArrayEnumerator<T>(newArray);
		}

	}

	class CycledArrayEnumerator<T> : IEnumerator<T>
	{
		T[] array;
		int position = -1;

		public CycledArrayEnumerator(T[] array)
		{
			this.array = array;
		}

		public T Current
		{
			get
			{
				if (position < 0 || position > array.Length)
					throw new ArgumentOutOfRangeException();
				else return array[position];
			}
		}

		object IEnumerator.Current
		{
			get
			{
				if (position < 0 || position > array.Length)
					throw new ArgumentOutOfRangeException();
				else return array[position];
			}
		}

		public void Dispose()
		{

		}

		public bool MoveNext()
		{
			if (position < array.Length - 1)
			{
				position++;
				return true;
			}
			else
			{
				position = 0;
				return true;
			}
		}

		public void Reset()
		{
			position = -1;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			List<int> list = new List<int> { 3, 3, 222, 444, 333, 999 };
			HardcoreDynamicArray<int> hda = new HardcoreDynamicArray<int>(list);
			Console.Write("Массив после изменения Capacity: ");
			hda.Capacity = 7;
			foreach (int item in hda)
			{
				Console.Write(item + " ");
			}
			Console.WriteLine();
			Console.WriteLine("Последний элемент: {0}", hda[-1]);
			HardcoreDynamicArray<int> hda2 = (HardcoreDynamicArray<int>)hda.Clone();
			Console.Write("Копия массива: ");
			foreach (int item in hda2)
			{
				Console.Write(item + " ");
			}
			Console.WriteLine();
			CycledArray<int> dontDoIt = new CycledArray<int>(list);
			Console.WriteLine("Это вывод циклического массива. Для старта нажмите любую клавишу. ");
			Console.ReadKey();
			foreach (int item in dontDoIt)
			{
				Console.WriteLine(item);
			}
		}
	}
}
