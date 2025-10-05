using Pokemon_Review_App.Models;

namespace Review_Review_App.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int pokemonId);
        Review CreateReview(Review pokemon);
        Review UpdateReview(Review pokemon);
        void DeleteReviewById(int pokemonId);
    }
}
