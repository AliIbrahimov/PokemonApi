using System.Resources;
using ApiPractise.DataAccess;
using ApiPractise.Interfaces;
using ApiPractise.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiPractise.Repository
{
    public class ReviewRepository:IReviewRepository
    {
        private readonly AppDbContext _context;
        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public Review GetReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviewsOfPokemon(int pokeId)
        {
            return _context.Reviews.Where(r => r.Pokemon.Id == pokeId).Include(p => p.Pokemon).ToList();
        }

        public bool ReviewExists(int reviewID)
        {
            return _context.Reviews.Any(r => r.Id == reviewID);
        }
    }
}
