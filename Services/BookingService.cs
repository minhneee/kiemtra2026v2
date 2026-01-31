using PickleballClubManagement.Models;

namespace PickleballClubManagement.Services
{
    public class BookingService : IBookingService
    {
        public async Task<bool> IsTimeSlotAvailableAsync(int courtId, DateTime startTime, DateTime endTime)
        {
            // Check for overlap on the specific court
            var hasOverlap = InMemoryDataStore.GetBookings().Any(b =>
                b.CourtId == courtId &&
                b.Status != BookingStatus.Cancelled &&
                startTime < b.EndTime && endTime > b.StartTime);
            
            return await Task.FromResult(!hasOverlap);
        }

        public async Task<Booking> CreateBookingAsync(int memberId, int courtId, DateTime startTime, DateTime endTime, string? notes)
        {
            var booking = new Booking
            {
                MemberId = memberId,
                CourtId = courtId,
                StartTime = startTime,
                EndTime = endTime,
                Status = BookingStatus.Confirmed,
                Notes = notes,
                CreatedAt = DateTime.Now
            };

            return await Task.FromResult(InMemoryDataStore.AddBooking(booking));
        }

        public async Task<List<Booking>> GetBookingsByDateAsync(DateTime date)
        {
            var startOfDay = date.Date;
            var endOfDay = startOfDay.AddDays(1);

            return await Task.FromResult(
                InMemoryDataStore.GetBookings()
                    .Where(b => b.StartTime >= startOfDay && b.StartTime < endOfDay && b.Status != BookingStatus.Cancelled)
                    .OrderBy(b => b.StartTime)
                    .ToList()
            );
        }

        public async Task<List<Booking>> GetMemberBookingsAsync(int memberId)
        {
            return await Task.FromResult(
                InMemoryDataStore.GetBookings()
                    .Where(b => b.MemberId == memberId)
                    .OrderByDescending(b => b.StartTime)
                    .ToList()
            );
        }
    }
}
