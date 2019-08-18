using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using BLL.Classes;
using BLL.Storages;

namespace DAL.Storages
{
	public class JsonStorage : IStorage
	{
		public const string JsonPath = @"C:\Users and Awards\JSON\";
		public const string UsersJsonName = @"Users.json";
		public const string AwardsJsonName = @"Awards.json";

		public const string UsersJsonPath = JsonPath + UsersJsonName;
		public const string AwardsJsonPath = JsonPath + AwardsJsonName;

		public JsonStorage()
		{
			if (!Directory.Exists(JsonPath))
			{
				Directory.CreateDirectory(JsonPath);
			}
			if (!File.Exists(JsonPath + UsersJsonName))
			{
				File.Create(JsonPath + UsersJsonName);
			}
			if (!File.Exists(JsonPath + AwardsJsonName))
			{
				File.Create(JsonPath + AwardsJsonName);
			}
		}

		public void Clear()
		{
			File.WriteAllText(UsersJsonPath, string.Empty);
			File.WriteAllText(AwardsJsonPath, string.Empty);
		}

		public List<Award> GetAllAwards()
		{
			DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Award[]));
			Award[] awards = new Award[0];

			if (new FileInfo(UsersJsonPath).Length != 0)
				using (FileStream fs = new FileStream(AwardsJsonPath, FileMode.OpenOrCreate))
				{
					awards = (Award[])jsonFormatter.ReadObject(fs);
				}

			return awards.ToList();
		}

		public List<User> GetAllUsers()
		{
			DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(User[]));
			User[] users = new User[0];

			if (new FileInfo(UsersJsonPath).Length != 0)
				using (FileStream fs = new FileStream(UsersJsonPath, FileMode.OpenOrCreate))
				{
					users = (User[])jsonFormatter.ReadObject(fs);
				}

			return users.ToList();
		}

		public void SaveAwards(List<Award> awards)
		{
			DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Award[]));
			using (FileStream fileStream = new FileStream(AwardsJsonPath, FileMode.OpenOrCreate))
			{
				jsonFormatter.WriteObject(fileStream, awards.ToArray());
			}
		}

		public void SaveUsers(List<User> users)
		{
			DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(User[]));
			using (FileStream fileStream = new FileStream(UsersJsonPath, FileMode.OpenOrCreate))
			{
				jsonFormatter.WriteObject(fileStream, users.ToArray());
			}
		}
	}
}
