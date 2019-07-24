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

			//Вставка IEnumerable
			List<int> vs = new List<int> { 0, 1, 2, 3, 4, 0, 1, 2, 3, 4, 0, 1, 2, 3, 4, 0, 1, 2, 3, 4 };
			array.AddRange(vs);

			//Вывод по индексу
			Console.WriteLine("Вывод по индексу 0: {0}", array[0]);

			//Вывод foreach
			Console.Write("Вывод foreach: ");
			foreach (int x in array)
			{
				Console.Write(x + " ");
			}
			Console.WriteLine();

			//Вставка по индексу
			array.Insert(999, 3);
			Console.Write("Вставка в позицию 3 числа 999: ");
			foreach (int x in array)
			{
				Console.Write(x + " ");
			}
			Console.WriteLine();

			//Удаление
			Console.Write("Введите число для удаления: ");
			if (!int.TryParse(Console.ReadLine(), out int res))
			{
				Console.WriteLine("Неверно введено число.");
				return;
			}
			if (!array.Remove(res))
				Console.WriteLine("Число не найдено.");
			else
			{
				Console.Write("Удаление числа {0}: ", res);
				foreach (int x in array)
				{
					Console.Write(x + " ");
				}
				Console.WriteLine();
			}

			//Создание массива из IEnumerable
			DynamicArray<int> vs1 = new DynamicArray<int>(vs);
			Console.Write("Создание массива из IEnumerable: ");
			foreach (int x in vs1)
			{
				Console.Write(x + " ");
			}
			Console.WriteLine();
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
			//Считаем количество элементов IEnumerable на входе
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
			//Считаем количество элементов IEnumerable на входе
			int tsLength = 0;
			foreach (T item in ts)
			{
				tsLength++;
			}
			//Выделяем капасити и пересоздаём массив(если нужно)
			if (Length + tsLength > Capacity)
			{
				int additionalCapacity = 8;
				int newCapacity = Capacity + tsLength + additionalCapacity;
				T[] buff = array;
				array = new T[newCapacity];
				Capacity = newCapacity;
				buff.CopyTo(array, 0);
			}
			//Добавляем элементы из IEnumerable в массив 
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
			for (int i = Length - 1; i > index; i--)
			{
				array[i] = array[i - 1];
			}
			array[index] = element;
		}

		/// <summary>
		/// Удаляет из массива первое вхождение элемента
		/// </summary>
		/// <param name="elem">Элемент для удаления</param>
		/// <returns>true, если элемент был удален. Иначе false.</returns>
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
