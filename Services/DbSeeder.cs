namespace PickleballClubManagement.Services
{
    /// <summary>
    /// No longer used - replaced by in-memory data store
    /// Kept for backward compatibility if someone tries to inject it
    /// </summary>
    public class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            // No-op - data is now stored in memory via InMemoryDataStore
            await Task.CompletedTask;
        }
    }
}
