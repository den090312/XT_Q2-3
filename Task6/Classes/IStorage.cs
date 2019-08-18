using BLL.Classes;
using System;
using System.Collections.Generic;

namespace BLL.Storages
{
	public interface IStorage
	{
		/// <summary>
		/// Get all users from storage
		/// </summary>
		/// <returns>All users in store</returns>
		List<User> GetAllUsers();

		/// <summary>
		/// Get all awards from storage
		/// </summary>
		/// <returns>All awards in store</returns>
		List<Award> GetAllAwards();

		/// <summary>
		/// Save users to storage
		/// </summary>
		/// <param name="user">user to store</param>
		void SaveUsers(List<User> users);

		/// <summary>
		/// Save awards to storage
		/// </summary>
		/// <param name="user">awards to store</param>
		void SaveAwards(List<Award> awards);

		/// <summary>
		/// Clear storage
		/// </summary>
		void Clear();
	}
}
