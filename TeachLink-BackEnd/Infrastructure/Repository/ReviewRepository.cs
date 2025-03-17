using Supabase;
using TeachLink_BackEnd.Core.Models;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.TeacherService
{
    public class ReviewRepository : IReviewRepository
    {
        Client _supabase;

        public ReviewRepository(SupabaseClientFactory supabaseClientFactory)
        {
            _supabase = supabaseClientFactory.CreateClient();
        }

        public async Task Create(int id_teacher, int id_student, ReviewsModel reviewsModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReviewsModel>?> GetAll(int id_teacher, int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task<ReviewsModel?> GetById(int id_teacher, int id_student)
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id_teacher, int id_student, ReviewsModel reviewModel)
        {
            throw new NotImplementedException();
        }
    }
}
