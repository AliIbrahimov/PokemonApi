using ApiPractise.Models;

namespace ApiPractise.Interfaces;

public interface IReviewRepository
{
    ICollection<Review> GetReviews();
    Review GetReview(int reviewId);
    ICollection<Review> GetReviewsOfPokemon(int pokeId);
    bool ReviewExists(int reviewId);
}