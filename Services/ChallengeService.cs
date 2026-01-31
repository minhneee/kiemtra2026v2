using PickleballClubManagement.Models;

namespace PickleballClubManagement.Services
{
    public class ChallengeService : IChallengeService
    {
        public async Task<List<Challenge>> GetOpenChallengesAsync()
        {
            return await Task.FromResult(
                InMemoryDataStore.GetChallenges()
                    .Where(c => c.Status == ChallengeStatus.Open)
                    .OrderByDescending(c => c.CreatedAt)
                    .ToList()
            );
        }

        public async Task<List<Challenge>> GetAcceptedChallengesAsync()
        {
            return await Task.FromResult(
                InMemoryDataStore.GetChallenges()
                    .Where(c => c.Status == ChallengeStatus.Accepted)
                    .OrderByDescending(c => c.CreatedAt)
                    .ToList()
            );
        }

        public async Task<List<Challenge>> GetAllChallengesAsync()
        {
            return await Task.FromResult(
                InMemoryDataStore.GetChallenges()
                    .OrderByDescending(c => c.CreatedAt)
                    .ToList()
            );
        }

        public async Task<Challenge> CreateChallengeAsync(int creatorId, string title, string description)
        {
            var challenge = new Challenge
            {
                CreatorId = creatorId,
                Title = title,
                Description = description,
                Status = ChallengeStatus.Open,
                Type = ChallengeType.Duel,
                CreatedAt = DateTime.Now
            };

            return await Task.FromResult(InMemoryDataStore.AddChallenge(challenge));
        }

        public async Task<Challenge> CreateAdvancedChallengeAsync(int creatorId, string title, string description, ChallengeType type, GameMode mode, decimal entryFee, decimal prizePool, int targetWins)
        {
            var challenge = new Challenge
            {
                CreatorId = creatorId,
                Title = title,
                Description = description,
                Status = type == ChallengeType.MiniGame ? ChallengeStatus.Ongoing : ChallengeStatus.Open,
                Type = type,
                ResultMode = mode,
                EntryFee = entryFee,
                PrizePool = prizePool,
                Config_TargetWins = targetWins,
                StartDate = DateTime.Now,
                CreatedAt = DateTime.Now
            };

            return await Task.FromResult(InMemoryDataStore.AddChallenge(challenge));
        }

        public async Task<bool> AcceptChallengeAsync(int challengeId)
        {
            var challenge = InMemoryDataStore.GetChallengeById(challengeId);
            if (challenge == null || challenge.Status != ChallengeStatus.Open)
            {
                return await Task.FromResult(false);
            }

            challenge.Status = ChallengeStatus.Accepted;
            InMemoryDataStore.UpdateChallenge(challenge);

            return await Task.FromResult(true);
        }

        public async Task<Challenge?> GetChallengeByIdAsync(int id)
        {
            return await Task.FromResult(InMemoryDataStore.GetChallengeById(id));
        }
    }
}
