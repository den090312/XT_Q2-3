using System;
using System.Collections;
using System.Collections.Generic;

namespace DYNAMIC_ARRAY
{
	class Program
	{
		static void Main(string[] args)
		{
			DynamicArray<int> array = new DynamicArray<int>();

			//Insert IEnumerable
			List<int> vs = new List<int> { 0, 1, 2, 3, 4, 0, 1, 2, 3, 4, 0, 1, 2, 3, 4, 0, 1, 2, 3, 4 };
			array.AddRange(vs);

			//Index output
			Console.WriteLine("Output at index 0: {0}", array[0]);

			//Foreach output
			Console.Write("Foreach output: ");
			foreach (int x in array)
			{
				Console.Write(x + " ");
			}
			Console.WriteLine();

			//Insert by index
			array.Insert(999, 3);
			Console.Write("Insert at position 3 of number 999: ");
			foreach (int x in array)
			{
				Console.Write(x + " ");
			}
			Console.WriteLine();

			//Deleting
			Console.Write("Enter the number to delete: ");
			if (!int.TryParse(Console.ReadLine(), out int res))
			{
				Console.WriteLine("Invalid number entered.");
				return;
			}
			if (!array.Remove(res))
				Console.WriteLine("Number not found.");
			else
			{
				Console.Write("Delete number {0}: ", res);
				foreach (int x in array)
				{
					Console.Write(x + " ");
				}
				Console.WriteLine();
			}

			//Creating an array of IEnumerable
			DynamicArray<int> vs1 = new DynamicArray<int>(vs);
			Console.Write("Creating an array of IEnumerable: ");
			foreach (int x in vs1)
			{
				Console.Write(x + " ");
			}
			Console.WriteLine();
		}

	}

	public class DynamicArray<T> : IEnumerable, IEnumerable<T>
	{
		protected T[] array;

		public int Length { get; protected set; }

		public int Capacity
		{
			get => array.Length;
			set
			{
				if (value < Length)
					throw new ArgumentOutOfRangeException("Wrong argument: capacity cannot be less then length");
				else
				{
					var temp = new T[Capacity];
					for (int i = 0; i < array.Length; i++)
					{
						temp[i] = array[i];
					}
					array = temp;
				}
			}
		}
		/// <summary>
		/// Returns an array element by index
		/// </summary>
		/// <param name="index">Item Index</param>
		/// <returns>Array element</returns>
		public T this[int index]
		{
			get
			{
				if (index < Length || index >= 0)
					return array[index];
				else throw new ArgumentOutOfRangeException("Wrong argument: index cannot be greater then array length or negative.");
			}
			set
			{
				if (index < Length || index < 0)
					array[index] = value;
				else throw new ArgumentOutOfRangeException("Wrong argument: index cannot be greater then array length or negative.");
			}
		}

		public DynamicArray()
		{
			int initCapacity = 8;
			array = new T[initCapacity];
			Length = 0;
		}

		public DynamicArray(int capacity)
		{
			array = new T[capacity];
			Length = 0;
		}

		public DynamicArray(IEnumerable<T> ts)
		{
			int additCapacity = 8;
			//Count the number of IEnumerable elements at the input
			int tsLength = 0;
			foreach (T item in ts)
			{
				tsLength++;
			}
			Length = tsLength;
			int newCapacity = additCapacity + tsLength;
			array = new T[newCapacity];

			int indexer = 0;
			foreach (T item in ts)
			{
				array[indexer] = item;
				indexer++;
			}
		}

		/// <summary>
		/// Adds an element to an array
		/// </summary>
		/// <param name="element">Item to add</param>
		public void Add(T element)
		{
			if (Length > Capacity)
				array = new T[Capacity * 2];
			array[Length] = element;
			Length++;
		}

		/// <summary>
		/// Adds all items from IEnumerable to the end of the array.
		/// </summary>
		/// <param name="ts">IEnumerable</param>
		public void AddRange(IEnumerable<T> ts)
		{
			//Count the number of IEnumerable elements at the input
			int tsLength = 0;
			foreach (T item in ts)
			{
				tsLength++;
			}
			//Select capacity and re-create the array (if needed)
			if (Length + tsLength > Capacity)
			{
				int additionalCapacity = 8;
				int newCapacity = Capacity + tsLength + additionalCapacity;
				T[] buff = array;
				array = new T[newCapacity];
				Capacity = newCapacity;
				buff.CopyTo(array, 0);
			}
			//We add elements from IEnumerable to an array
			int index = Length;
			foreach (T item in ts)
			{
				array[index] = item;
				index++;
			}
			Length += tsLength;
		}

		/// <summary>
		/// Insert new item at index position
		/// </summary>
		/// <param name="element">Item to insert</param>
		/// <param name="index">Position to insert</param>
		public void Insert(T element, int index)
		{
			if (index < 0 || index >= Length)
				throw new ArgumentOutOfRangeException("Wrong argument: index cannot be greater then array length or negative.");
			if (Length >= Capacity)
				array = new T[Capacity * 2];
			Length++;
			for (int i = Length - 1; i > index; i--)
			{
				array[i] = array[i - 1];
			}
			array[index] = element;
		}

		/// <summary>
		/// Removes the first occurrence of an element from an array.
		/// </summary>
		/// <param name="elem">Item to remove</param>
		/// <returns>true if the item has been deleted. Otherwise false.</returns>
		public bool Remove(T elem)
		{
			for (int i = 0; i < Length; i++)
			{
				if (array[i].Equals(elem))
				{
					for (int j = i; j < Length - 1; j++)
					{
						T buf = array[j + 1];
						array[j + 1] = array[j];
						array[j] = buf;
					}
					array[Length - 1] = default;
					Length--;
					return true;
				}
			}
			return false;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			T[] newArray = new T[Length];
			Array.Copy(array, newArray, Length);
			return new DynamicArrayEnumerator<T>(newArray);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			T[] newArray = new T[Length];
			Array.Copy(array, newArray, Length);
			return newArray.GetEnumerator();
		}

	}

	class DynamicArrayEnumerator<T> : IEnumerator<T>
	{
		T[] array;
		int position = -1;

		public DynamicArrayEnumerator(T[] array)
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
			return false;
		}

		public void Reset()
		{
			position = -1;
		}
	}
}
