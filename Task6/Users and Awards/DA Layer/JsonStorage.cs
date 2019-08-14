using System.IO;
using System.Runtime.Serialization.Json;
using BLL.Classes;

namespace DAL.Storages
{
	public class JsonStorage : IStorage
	{
		public const string JsonPath = @"C:\Users and Awards\JSON\Users.json";

		public User[] GetAllUsers()
		{
			DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(User[]));
			User[] users;

			using (FileStream fs = new FileStream(JsonPath, FileMode.OpenOrCreate))
			{
				users = (User[])jsonFormatter.ReadObject(fs);
			}

			return users;
		}

		public User GetUserById(string id)
		{

		}

		public void SaveUser(User user)
		{

		}
	}
}
