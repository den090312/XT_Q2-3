using System;
using System.Collections.Generic;
using BLL.Classes;

namespace BLL
{
	public class BLLMain
	{
		public List<User> users { get; private set; }
		public List<Award> awards { get; private set; }

		public BLLMain()
		{
			users = Dependencies.storage.GetAllUsers();
			awards = Dependencies.storage.GetAllAwards();
		}

		public Award GetAwardById(Guid id) => awards.Find(x => x.id == id);

		public User GetAwardByUser(Guid id) => users.Find(x => x.id == id);

		public void RemoveAward(Guid id)
		{
			Award award = awards.Find(x => x.id == id);
			if (award == null)
			{
				throw new ArgumentOutOfRangeException($"No award with {id} found");
			}
			//Remove award from users
			foreach (User x in users)
			{
				List<Guid> userAwards = x.GetAwards();
				userAwards.RemoveAll(item => item == id);
			}

			//Remove award
			awards.Remove(award);
		}

		public void RemoveUser(Guid id)
		{
			User user = users.Find(x => x.id == id);
			if (user == null)
			{
				throw new ArgumentOutOfRangeException($"No user with {id} found");
			}
			//Remove award from users
			foreach (Award x in awards)
			{
				List<Guid> awardOwners = x.GetOwners();
				awardOwners.RemoveAll(item => item == id);
			}
			//Remove award
			users.Remove(user);
		}

		public void RemoveAwardFromUser(Guid userId, Guid awardId)
		{
			Award award = awards.Find(x => x.id == awardId);
			if (award == null)
			{
				throw new ArgumentOutOfRangeException($"No award with {awardId} found");
			}

			User user = users.Find(x => x.id == userId);
			if (user == null)
			{
				throw new ArgumentOutOfRangeException($"No user with {userId} found");
			}
			award.RemoveOwner(userId);
			user.RemoveAward(awardId);
		}

		public void AddAwardToUser(Guid userId, Guid awardId)
		{
			Award award = awards.Find(x => x.id == awardId);
			if (award == null)
			{
				throw new ArgumentOutOfRangeException($"No award with {awardId} found");
			}

			User user = users.Find(x => x.id == userId);
			if (user == null)
			{
				throw new ArgumentOutOfRangeException($"No user with {userId} found");
			}

			if (user.GetAwards().Contains(awardId))
			{
				throw new ArgumentException($"User with {userId} already has award with {awardId}");
			}

			award.AddOwner(userId);
			user.AddAward(awardId);
		}

		public void AddNewAward(Award award) => awards.Add(award);

		public void AddNewUser(User user) => users.Add(user);

		public Award[] GetAllAwards() => awards.ToArray();

		public User[] GetAllUsers() => users.ToArray();

		public void SaveAll()
		{
			Dependencies.storage.Clear();
			Dependencies.storage.SaveAwards(awards);
			Dependencies.storage.SaveUsers(users);
		}

	}
}
