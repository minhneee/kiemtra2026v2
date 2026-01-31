using PickleballClubManagement.Models;

namespace PickleballClubManagement.Services
{
    /// <summary>
    /// In-memory user store for authentication (no database)
    /// </summary>
    public static class InMemoryUserStore
    {
        private static Dictionary<string, (string password, string email, string fullName, List<string> roles)> _users = new();

        static InMemoryUserStore()
        {
            // Initialize with a default admin user
            _users["admin"] = ("admin123", "admin@pickleball.com", "Admin User", new List<string> { "Admin" });
        }

        public static bool TryRegisterUser(string username, string password, string email, string fullName)
        {
            if (_users.ContainsKey(username))
                return false;

            _users[username] = (password, email, fullName, new List<string>());
            return true;
        }

        public static bool TryAuthenticate(string username, string password)
        {
            return _users.TryGetValue(username, out var user) && user.password == password;
        }

        public static (string email, string fullName, List<string> roles)? GetUserInfo(string username)
        {
            if (_users.TryGetValue(username, out var user))
                return (user.email, user.fullName, user.roles);
            return null;
        }

        public static List<string> GetUserRoles(string username)
        {
            if (_users.TryGetValue(username, out var user))
                return user.roles;
            return new List<string>();
        }

        public static bool UserExists(string username)
        {
            return _users.ContainsKey(username);
        }
    }
}
