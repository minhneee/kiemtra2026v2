using PickleballClubManagement.Models;

namespace PickleballClubManagement.Services
{
    public class MatchService : IMatchService
    {
        public async Task<Match> CreateMatchAsync(
            int? challengeId, 
            MatchFormat format, 
            int winner1Id, 
            int? winner2Id, 
            int loser1Id, 
            int? loser2Id, 
            bool isRanked,
            List<(int winnerScore, int loserScore)>? sets = null)
        {
            // Create match
            var match = new Match
            {
                ChallengeId = challengeId,
                Format = format,
                Winner1Id = winner1Id,
                Winner2Id = winner2Id,
                Loser1Id = loser1Id,
                Loser2Id = loser2Id,
                IsRanked = isRanked,
                MatchDate = DateTime.Now
            };

            var addedMatch = InMemoryDataStore.AddMatch(match);

            // Add match sets if provided
            if (sets != null && sets.Count > 0)
            {
                for (int i = 0; i < sets.Count; i++)
                {
                    var set = new MatchSet
                    {
                        MatchId = addedMatch.Id,
                        SetNumber = i + 1,
                        TeamAScore = sets[i].winnerScore,
                        TeamBScore = sets[i].loserScore
                    };
                    InMemoryDataStore.AddMatchSet(set);
                }
            }

            // If match is linked to a challenge, update challenge status to Completed
            if (challengeId.HasValue)
            {
                var challenge = InMemoryDataStore.GetChallengeById(challengeId.Value);
                if (challenge != null)
                {
                    challenge.Status = ChallengeStatus.Completed;
                    InMemoryDataStore.UpdateChallenge(challenge);
                }
            }

            // Update rankings if match is ranked
            if (isRanked)
            {
                await UpdateRankingsAsync(addedMatch);
            }

            return addedMatch;
        }

        private async Task UpdateRankingsAsync(Match match)
        {
            // Add 0.1 to winners
            await UpdateMemberRankAsync(match.Winner1Id, 0.1);
            if (match.Winner2Id.HasValue)
            {
                await UpdateMemberRankAsync(match.Winner2Id.Value, 0.1);
            }

            // Subtract 0.1 from losers (minimum 1.0)
            await UpdateMemberRankAsync(match.Loser1Id, -0.1);
            if (match.Loser2Id.HasValue)
            {
                await UpdateMemberRankAsync(match.Loser2Id.Value, -0.1);
            }
        }

        private async Task UpdateMemberRankAsync(int memberId, double delta)
        {
            var member = InMemoryDataStore.GetMemberById(memberId);
            if (member != null)
            {
                member.RankLevel = Math.Max(1.0, member.RankLevel + delta);
                InMemoryDataStore.UpdateMember(member);
            }
            await Task.CompletedTask;
        }

        public async Task<List<Match>> GetMatchHistoryAsync(int? memberId = null)
        {
            var matches = InMemoryDataStore.GetMatches()
                .OrderByDescending(m => m.MatchDate)
                .ToList();

            if (memberId.HasValue)
            {
                matches = matches.Where(m =>
                    m.Winner1Id == memberId ||
                    m.Winner2Id == memberId ||
                    m.Loser1Id == memberId ||
                    m.Loser2Id == memberId)
                    .ToList();
            }

            // Populate navigation properties and sets
            foreach (var match in matches)
            {
                // Populate member navigation properties
                match.Winner1 = InMemoryDataStore.GetMemberById(match.Winner1Id);
                if (match.Winner2Id.HasValue)
                    match.Winner2 = InMemoryDataStore.GetMemberById(match.Winner2Id.Value);
                match.Loser1 = InMemoryDataStore.GetMemberById(match.Loser1Id);
                if (match.Loser2Id.HasValue)
                    match.Loser2 = InMemoryDataStore.GetMemberById(match.Loser2Id.Value);

                // Populate challenge if exists
                if (match.ChallengeId.HasValue)
                    match.Challenge = InMemoryDataStore.GetChallengeById(match.ChallengeId.Value);

                // Populate match sets
                match.Sets = InMemoryDataStore.GetMatchSets()
                    .Where(s => s.MatchId == match.Id)
                    .OrderBy(s => s.SetNumber)
                    .ToList();
            }

            return await Task.FromResult(matches);
        }

        public async Task<Match?> GetMatchByIdAsync(int id)
        {
            return await Task.FromResult(InMemoryDataStore.GetMatchById(id));
        }
    }
}
