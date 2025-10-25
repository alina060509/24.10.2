using homeWork.Entities;
using Entity_Framework.Configurations;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework.Repositories
{
    public class ReviewRepository
    {
        private readonly DBContext _db;

        public ReviewRepository(DBContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Review review)
        {
            await _db.Reviews.AddAsync(review);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveAsync(Review review)
        {
            _db.Reviews.Remove(review);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Review review)
        {
            _db.Reviews.Update(review);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Review>> GetAllAsync()
        {
            var reviews = await _db.Reviews.ToListAsync();
            return reviews;
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            var review = await _db.Reviews.FindAsync(id);
            return review;
        }

        public async Task<Review> GetByRatingAsync(int rating)
        {
            var review = await _db.Reviews.FirstOrDefaultAsync(r => r.Rating == rating);
            return review;
        }
    }
}
