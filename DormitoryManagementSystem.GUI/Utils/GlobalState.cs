using DormitoryManagementSystem.API.Models;

namespace DormitoryManagementSystem.GUI.Utils
{
    internal static class GlobalState
    {
        private static readonly object SyncObj = new();

        public static UserSession? CurrentUser { get; private set; }
        public static string? AuthToken { get; private set; }

        public static void SetUser(UserSession session, string? token = null)
        {
            lock (SyncObj)
            {
                CurrentUser = session;
                AuthToken = token;
            }
        }

        public static void Clear()
        {
            lock (SyncObj)
            {
                CurrentUser = null;
                AuthToken = null;
            }
        }
    }
}

