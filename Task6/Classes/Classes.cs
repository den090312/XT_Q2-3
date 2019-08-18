using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BLL.Classes
{

	[DataContract]
	public class User
	{

		[DataMember]
		private List<Guid> userAwards = new List<Guid>();
		[DataMember]
		public readonly Guid id;
		[DataMember]
		public string Name { get; private set; }
		[DataMember]
		public DateTime DateOfBirth { get; private set; }

		public int Age
		{
			get
			{
				DateTime now = DateTime.Today;
				int age = now.Year - DateOfBirth.Year;
				if (DateOfBirth > now.AddYears(-age)) age--;
				return age;
			}
		}

		#region Constructors
		public User(string Name, string DateOfBirth)
		{
			this.Name = Name;
			if (DateTime.TryParse(DateOfBirth, out DateTime date))
			{
				this.DateOfBirth = date;
			}
			else throw new FormatException("Date string was formatted incorrectly");
			id = Guid.NewGuid();
			userAwards = new List<Guid>();
		}

		public User(string Name, DateTime DateOfBirth)
		{
			this.Name = Name;
			this.DateOfBirth = DateOfBirth;
			id = Guid.NewGuid();
			userAwards = new List<Guid>();
		}

		public User(string Name, string DateOfBirth, List<Guid> awards)
		{
			this.Name = Name;
			if (DateTime.TryParse(DateOfBirth, out DateTime date))
			{
				this.DateOfBirth = date;
			}
			else throw new FormatException("Date string was formatted incorrectly");
			id = Guid.NewGuid();
			userAwards = awards;
		}
		#endregion

		public void AddAward(Guid award)
		{
			if (award == null)
				throw new ArgumentNullException($"Argument {nameof(award)} was null");
			userAwards.Add(award);
		}

		public List<Guid> GetAwards() => userAwards;

		public void AddAward(List<Guid> awards) => userAwards.AddRange(awards);

		public void RemoveAward(Guid award)
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
		private List<Guid> owners = new List<Guid>();

		[DataMember]
		public readonly Guid id;

		[DataMember]
		public string Name { get; private set; }

		public List<Guid> GetOwners() => owners;

		public void AddOwner(Guid ownerId) => owners.Add(ownerId);

		public void AddOwner(List<Guid> ownerIds) => owners.AddRange(ownerIds);

		public void RemoveOwner(Guid ownerId)
		{
			if (!owners.Contains(ownerId))
				throw new ArgumentOutOfRangeException("Wrong argument: award has no such owner.");
			owners.Remove(ownerId);
		}

		#region Constructors
		public Award(string Name)
		{
			this.Name = Name;
			id = Guid.NewGuid();
		}
		public Award(string Name, List<Guid> owners)
		{
			this.Name = Name;
			this.owners = owners;
			id = Guid.NewGuid();
		}
		#endregion
	}

}