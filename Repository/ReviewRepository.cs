using Pokemon_Review_App.Data;
using Pokemon_Review_App.Models;
using Review_Review_App.Interfaces;

namespace Review_Review_App.Repository;

public class ReviewRepository : IReviewRepository
{
    private readonly DataContext _context;

    public ReviewRepository(DataContext context)
    {
        _context = context;
    }

    public ICollection<Review> GetReviews()
    {
        return _context.Reviews.ToList();
    }

    public Review GetReview(int pokemonId)
    {
        return _context.Reviews.Find(pokemonId) ?? throw new InvalidOperationException();
    }

    public Review CreateReview(Review pokemon)
    {
        _context.Reviews.Add(pokemon);
        _context.SaveChanges();       
        return pokemon;
    }

    public Review UpdateReview(Review pokemon)
    {
        _context.Reviews.Update(pokemon);
        _context.SaveChanges();       
        return pokemon;
    }

    public void DeleteReviewById(int pokemonId)
    {
        _context.Reviews.Remove(GetReview(pokemonId));
        _context.SaveChanges();
    }
}