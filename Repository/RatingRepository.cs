using Entities;

namespace Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly MyStoreContext _myStoreContext;

        public RatingRepository(MyStoreContext myStoreContext)
        {
            _myStoreContext = myStoreContext;

        }
        public async Task<Rating> AddRatingAsync(Rating rating)
        {
            await _myStoreContext.Rating.AddAsync(rating);
            await _myStoreContext.SaveChangesAsync();
            return rating;
        }
    }
}
