using PickleballClubManagement.Models;

namespace PickleballClubManagement.Services
{
    /// <summary>
    /// In-memory data store for the application (no database needed)
    /// </summary>
    public static class InMemoryDataStore
    {
        private static List<Member> _members = new();
        private static List<Challenge> _challenges = new();
        private static List<Match> _matches = new();
        private static List<MatchSet> _matchSets = new();
        private static List<Booking> _bookings = new();
        private static List<Court> _courts = new();
        private static List<News> _news = new();
        private static List<Transaction> _transactions = new();
        private static List<TransactionCategory> _transactionCategories = new();
        private static List<Participant> _participants = new();
        
        private static int _memberIdCounter = 1;
        private static int _challengeIdCounter = 1;
        private static int _matchIdCounter = 1;
        private static int _matchSetIdCounter = 1;
        private static int _bookingIdCounter = 1;
        private static int _courtIdCounter = 1;

        static InMemoryDataStore()
        {
            InitializeSampleData();
        }

        private static void InitializeSampleData()
        {
            // Initialize sample members
            _members.Add(new Member { Id = _memberIdCounter++, IdentityUserId = "user1", FullName = "Nguyễn Văn A", Status = "Active", RankLevel = 2.5 });
            _members.Add(new Member { Id = _memberIdCounter++, IdentityUserId = "user2", FullName = "Trần Thị B", Status = "Active", RankLevel = 3.0 });
            _members.Add(new Member { Id = _memberIdCounter++, IdentityUserId = "user3", FullName = "Phạm Văn C", Status = "Active", RankLevel = 2.0 });

            // Initialize courts
            _courts.Add(new Court { Id = _courtIdCounter++, Name = "Court 1", Description = "Indoor Court - Area A", IsActive = true });
            _courts.Add(new Court { Id = _courtIdCounter++, Name = "Court 2", Description = "Indoor Court - Area A", IsActive = true });
            _courts.Add(new Court { Id = _courtIdCounter++, Name = "Court 3", Description = "Outdoor Court - Area B", IsActive = true });

            // Initialize sample transaction categories - Income
            _transactionCategories.Add(new TransactionCategory { Id = 1, Name = "Court Booking Fee", Type = TransactionType.Income });
            _transactionCategories.Add(new TransactionCategory { Id = 2, Name = "Tournament Fee", Type = TransactionType.Income });
            _transactionCategories.Add(new TransactionCategory { Id = 3, Name = "Membership Fee", Type = TransactionType.Income });
            
            // Initialize sample transaction categories - Expense
            _transactionCategories.Add(new TransactionCategory { Id = 4, Name = "Court Maintenance", Type = TransactionType.Expense });
            _transactionCategories.Add(new TransactionCategory { Id = 5, Name = "Equipment & Supplies", Type = TransactionType.Expense });
            _transactionCategories.Add(new TransactionCategory { Id = 6, Name = "Staff Salary", Type = TransactionType.Expense });
            _transactionCategories.Add(new TransactionCategory { Id = 7, Name = "Prize & Awards", Type = TransactionType.Expense });

            // Initialize sample challenges
            _challenges.Add(new Challenge 
            { 
                Id = _challengeIdCounter++, 
                CreatorId = 1, 
                Title = "Kèo 500k - Chấp nửa trái", 
                Description = "Tìm đối thủ cho trận đấu 1vs1 với tiền cược 500k",
                Status = ChallengeStatus.Open,
                Type = ChallengeType.Duel,
                CreatedAt = DateTime.Now.AddHours(-2)
            });
            _challenges.Add(new Challenge 
            { 
                Id = _challengeIdCounter++, 
                CreatorId = 2, 
                Title = "Giải đấu Mini - Team Battle", 
                Description = "Tổ chức giải đấu team 4v4, mỗi team 4 người",
                Status = ChallengeStatus.Ongoing,
                Type = ChallengeType.MiniGame,
                ResultMode = GameMode.TeamBattle,
                EntryFee = 100000,
                PrizePool = 400000,
                Config_TargetWins = 5,
                CreatedAt = DateTime.Now.AddHours(-1)
            });

            // Initialize sample matches
            _matches.Add(new Match 
            { 
                Id = _matchIdCounter++,
                MatchDate = DateTime.Now.AddDays(-1),
                Format = MatchFormat.Singles,
                IsRanked = true,
                Winner1Id = 1,
                Loser1Id = 2,
                WinningSide = WinningSide.Team1
            });
            
            var match2 = new Match 
            { 
                Id = _matchIdCounter++,
                MatchDate = DateTime.Now.AddDays(-2),
                Format = MatchFormat.Doubles,
                IsRanked = true,
                Winner1Id = 1,
                Winner2Id = 3,
                Loser1Id = 2,
                Loser2Id = 1,
                WinningSide = WinningSide.Team1
            };
            _matches.Add(match2);
            
            // Add match sets for match2
            var set1 = new MatchSet { Id = _matchSetIdCounter++, MatchId = match2.Id, SetNumber = 1, TeamAScore = 11, TeamBScore = 8 };
            var set2 = new MatchSet { Id = _matchSetIdCounter++, MatchId = match2.Id, SetNumber = 2, TeamAScore = 11, TeamBScore = 7 };
            _matchSets.Add(set1);
            _matchSets.Add(set2);
            match2.Sets.Add(set1);
            match2.Sets.Add(set2);
        }

        // Member operations
        public static List<Member> GetMembers() => new(_members);
        
        public static Member? GetMemberById(int id) => _members.FirstOrDefault(m => m.Id == id);
        
        public static Member? GetMemberByUserId(string userId) => _members.FirstOrDefault(m => m.IdentityUserId == userId);
        
        public static Member AddMember(Member member)
        {
            member.Id = _memberIdCounter++;
            _members.Add(member);
            return member;
        }
        
        public static void UpdateMember(Member member)
        {
            var existing = _members.FirstOrDefault(m => m.Id == member.Id);
            if (existing != null)
            {
                _members.Remove(existing);
                _members.Add(member);
            }
        }

        // Challenge operations
        public static List<Challenge> GetChallenges() => new(_challenges);
        
        public static Challenge? GetChallengeById(int id) => _challenges.FirstOrDefault(c => c.Id == id);
        
        public static Challenge AddChallenge(Challenge challenge)
        {
            challenge.Id = _challengeIdCounter++;
            _challenges.Add(challenge);
            return challenge;
        }
        
        public static void UpdateChallenge(Challenge challenge)
        {
            var existing = _challenges.FirstOrDefault(c => c.Id == challenge.Id);
            if (existing != null)
            {
                _challenges.Remove(existing);
                _challenges.Add(challenge);
            }
        }

        // Match operations
        public static List<Match> GetMatches() => new(_matches);
        
        public static Match? GetMatchById(int id) => _matches.FirstOrDefault(m => m.Id == id);
        
        public static Match AddMatch(Match match)
        {
            match.Id = _matchIdCounter++;
            _matches.Add(match);
            return match;
        }
        
        public static void UpdateMatch(Match match)
        {
            var existing = _matches.FirstOrDefault(m => m.Id == match.Id);
            if (existing != null)
            {
                _matches.Remove(existing);
                _matches.Add(match);
            }
        }

        // MatchSet operations
        public static List<MatchSet> GetMatchSets() => new(_matchSets);
        
        public static List<MatchSet> GetMatchSetsByMatchId(int matchId) => _matchSets.Where(ms => ms.MatchId == matchId).ToList();
        
        public static MatchSet AddMatchSet(MatchSet matchSet)
        {
            matchSet.Id = _matchSetIdCounter++;
            _matchSets.Add(matchSet);
            return matchSet;
        }

        // Booking operations
        public static List<Booking> GetBookings() => new(_bookings);
        
        public static Booking? GetBookingById(int id) => _bookings.FirstOrDefault(b => b.Id == id);
        
        public static Booking AddBooking(Booking booking)
        {
            booking.Id = _bookingIdCounter++;
            _bookings.Add(booking);
            return booking;
        }
        
        public static void UpdateBooking(Booking booking)
        {
            var existing = _bookings.FirstOrDefault(b => b.Id == booking.Id);
            if (existing != null)
            {
                _bookings.Remove(existing);
                _bookings.Add(booking);
            }
        }

        // Court operations
        public static List<Court> GetCourts() => new(_courts);
        
        public static Court? GetCourtById(int id) => _courts.FirstOrDefault(c => c.Id == id);

        // News operations
        public static List<News> GetNews() => new(_news);
        
        public static News AddNews(News news)
        {
            _news.Add(news);
            return news;
        }

        // Transaction operations
        public static List<Transaction> GetTransactions() => new(_transactions);
        
        public static Transaction AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
            return transaction;
        }

        // TransactionCategory operations
        public static List<TransactionCategory> GetTransactionCategories() => new(_transactionCategories);
        
        public static TransactionCategory? GetTransactionCategoryById(int id) => _transactionCategories.FirstOrDefault(tc => tc.Id == id);

        // Participant operations
        public static List<Participant> GetParticipants() => new(_participants);
        
        public static Participant AddParticipant(Participant participant)
        {
            _participants.Add(participant);
            return participant;
        }
    }
}
