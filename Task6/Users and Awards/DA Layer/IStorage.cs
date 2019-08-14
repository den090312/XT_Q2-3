using BLL.Classes;
using System;

namespace DAL.Storages
{
	public interface IStorage
	{
		/// <summary>
		/// Save users to storage
		/// </summary>
		/// <param name="user">user to store</param>
		void SaveUser(User user);

		/// <summary>
		/// Get all users from store
		/// </summary>
		/// <returns>All users in store</returns>
		User[] GetAllUsers();

		/// <summary>
		/// Gets user by id from store
		/// </summary>
		/// <param name="id">user id</param>
		/// <returns>user by id</returns>
		/// <exception cref="ArgumentOutOfRangeException">User with id not found</exception> 
		User GetUserById(string id);
	}
}
