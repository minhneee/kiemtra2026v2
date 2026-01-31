using PickleballClubManagement.Models;

namespace PickleballClubManagement.Services
{
    public class MemberService : IMemberService
    {
        public async Task<Member?> GetMemberByUserIdAsync(string userId)
        {
            return await Task.FromResult(InMemoryDataStore.GetMemberByUserId(userId));
        }

        public async Task<Member?> GetMemberByIdAsync(int id)
        {
            return await Task.FromResult(InMemoryDataStore.GetMemberById(id));
        }

        public async Task<Member> CreateMemberAsync(string userId, string fullName)
        {
            var member = new Member
            {
                IdentityUserId = userId,
                FullName = fullName,
                Status = "Active",
                RankLevel = 1.0
            };

            return await Task.FromResult(InMemoryDataStore.AddMember(member));
        }

        public async Task<List<Member>> GetAllMembersAsync()
        {
            return await Task.FromResult(
                InMemoryDataStore.GetMembers()
                    .Where(m => m.Status == "Active")
                    .OrderBy(m => m.FullName)
                    .ToList()
            );
        }
    }
}
