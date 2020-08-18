using DB.Models;

namespace Logic.Repository
{
    public static class RepositorySingleton
    {
        public static PersonalWebSiteContext context;
        public static readonly object lockObj = new object();

        public static PersonalWebSiteContext GetInstance()
        {
            lock(lockObj)
            {
                if (context == null)
                {
                    context = new PersonalWebSiteContext();
                }
                return context;
            }
        }
    }
}