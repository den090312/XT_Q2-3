using DAL.Storages;

namespace Dependencies
{
	static class Dependencies
	{
		public static readonly IStorage storage = new JsonStorage();
	}
}
