using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BLL.Classes
{

	[DataContract]
	public class User
	{
		private int age;

		[DataMember]
		private List<Award> userAwards;
		[DataMember]
		public readonly Guid id;
		[DataMember]
		public string Name { get; private set; }
		[DataMember]
		public DateTime DateOfBirth { get; private set; }
		[DataMember]
		public int Age
		{
			get => age;
			private set
			{
				if (age >= 0)
					age = value;
				else throw new ArgumentException("Wrong argument: age cannot be zero or negative");
			}
		}

		#region Constructors
		public User(string Name, string DateOfBirth, int Age)
		{
			this.Name = Name;
			this.Age = Age;
			if (DateTime.TryParse(DateOfBirth, out DateTime date))
			{
				this.DateOfBirth = date;
			}
			else throw new FormatException("Date string was formatted incorrectly");
			id = Guid.NewGuid();
			userAwards = new List<Award>();
		}

		public User(string Name, DateTime DateOfBirth, int Age)
		{
			this.Name = Name;
			this.Age = Age;
			this.DateOfBirth = DateOfBirth;
			id = Guid.NewGuid();
			userAwards = new List<Award>();
		}
		#endregion

		public void AddAward(Award award)
		{
			if (award == null)
				throw new ArgumentNullException($"Argument {nameof(award)} was null");
			userAwards.Add(award);
		}

		public Award[] GetAwards() => userAwards.ToArray();

		public void AddAward(List<Award> awards) => userAwards.AddRange(awards);

		public void RemoveAward(Award award)
		{
			if (!userAwards.Contains(award))
				throw new ArgumentOutOfRangeException("Wrong argument: user has no such reward.");
			userAwards.Remove(award);
		}
	}

	[DataContract]
	public class Award
	{
		[DataMember]
		public readonly Guid id;

		[DataMember]
		public string Name { get; private set; }

		public Award(string Name)
		{
			this.Name = Name;
			id = Guid.NewGuid();
		}
	}

}