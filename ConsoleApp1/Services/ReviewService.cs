using homeWork.Entities;
using Entity_Framework.Configurations;
using Entity_Framework.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Services
{
    public class ReviewServices
    {
        private readonly ReviewRepository _ReviewRepository;

        public ReviewServices(DBContext db)
        {
            _ReviewRepository = new ReviewRepository(db);
        }

        public async Task AddAsync(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(Review));
            }

            var rev = _ReviewRepository.GetByRatingAsync(review.Rating);

            if (rev != null)
            {
                throw new Exception($"Отзыв с таким рейтингом {review.Rating} уже существует");
            }
            await _ReviewRepository.AddAsync(review);
        }

        public async Task RemoveAsync(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }

            var rev = _ReviewRepository.GetByRatingAsync(review.Rating);

            if (rev == null)
            {
                throw new Exception($"Отзыва с таким рейтингом {review.Rating} не  существует");
            }

            await _ReviewRepository.RemoveAsync(review);
        }

        public async Task UpdateAsync(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }

            var rev = _ReviewRepository.GetByRatingAsync(review.Rating);

            if (rev != null)
            {
                throw new Exception($"Отзыв с таким номером {review.Rating} обновлен");
            }

            await _ReviewRepository.UpdateAsync(review);
        }

        public async Task<List<Review>> GetAllAsync()
        {
            var reviews = await _ReviewRepository.GetAllAsync();
            return reviews;
        }


    }
}

