using Entities;

namespace Repository
{
    public interface IRatingRepository
    {
        Task<Rating> AddRatingAsync(Rating rating);
    }
}