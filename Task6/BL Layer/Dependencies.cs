using BLL.Storages;
using DAL.Storages;

namespace BLL
{
	static class Dependencies
	{
		public static readonly IStorage storage = new JsonStorage();
	}
}
