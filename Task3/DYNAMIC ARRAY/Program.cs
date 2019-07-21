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
			array.Add(10);
			List<int> vs = new List<int>{ 0, 1, 2, 3, 4 };
			array.AddRange(vs);
			for (int i = 0; i < array.Length; i++)
			{
				Console.WriteLine(array[i]);
			}
		}

	}

	class DynamicArray<T> : IEnumerable, IEnumerable<T>
	{
		private T[] array;
		/// <summary>
		/// Длина массива
		/// </summary>
		public int Length { get; private set; }
		/// <summary>
		/// Ёмкость массива
		/// </summary>
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
		/// Возвращает элемент массива по индексу
		/// </summary>
		/// <param name="index">Индекс элемента</param>
		/// <returns>Элемент массива</returns>
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
			array = new T[8];
			Length = 0;
		}

		public DynamicArray(int capacity)
		{
			array = new T[capacity];
			Length = 0;
		}
		/// <summary>
		/// Добавляет элемент в массив
		/// </summary>
		/// <param name="element">Элемент для добавления</param>
		public void Add(T element)
		{
			if (Length > Capacity)
				array = new T[Capacity * 2];
			array[Length] = element;
			Length++;
		}

		/// <summary>
		/// Добавляет все элементы из IEnumerable в конец массива
		/// </summary>
		/// <param name="ts">IEnumerable</param>
		public void AddRange(IEnumerable<T> ts)
		{
			int tsLength = 0;
			foreach (T item in ts)
			{
				tsLength++;
			}

			if (Length + tsLength > Capacity)
				Capacity = Length + tsLength;

			int index = Length;
			foreach (T item in ts)
			{
				array[index] = item;
				index++;
			}
			Length += tsLength;
		}

		/// <summary>
		/// Вставяет новый элемент в позицию index
		/// </summary>
		/// <param name="element">Элемент для вставки</param>
		/// <param name="index">Позиция для вставки</param>
		public void Insert(T element, int index)
		{
			if (index < 0 || index >= Length)
				throw new ArgumentOutOfRangeException("Wrong argument: index cannot be greater then array length or negative.");
			if (Length >= Capacity)
				array = new T[Capacity * 2];
			Length++;
			for (int i = Length - 1; i > index ; i--)
			{
				array[i] = array[i - 1];
			}
			array[index] = element;
		}

		public bool Remove(T elem)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Equals(elem))
				{
					for (int j = Length - 1; j < i; j++)
					{
						array[j - 1] = array[j];
					}
					Length--;
					return true;
				}
			}
			return false;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
