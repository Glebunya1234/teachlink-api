using Supabase;
using Supabase.Postgrest.Models;
using TeachLink_BackEnd.Core.Entities;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.TeacherService
{
    //public class BaseRepository<T>
    //    where T : BaseModel, new()
    //{
    //    protected readonly Client _supabase;

    //    protected BaseRepository(SupabaseClientFactory supabaseClientFactory)
    //    {
    //        _supabase = supabaseClientFactory.CreateClient();
    //    }

    //    public virtual async Task Create(T entity)
    //    {
    //        await _supabase.From<T>().Insert(entity);
    //    }

    //    public virtual async Task<List<T>?> GetAll()
    //    {
    //        //var result = await _supabase.From<T>().Get();

    //        //return result.Models;
    //        throw new NotImplementedException();
    //    }

    //    public virtual async Task<List<T>?> GetAll(int offset, int limit)
    //    {
    //        var result = await _supabase.From<T>().Get();

    //        return result.Models;
    //    }
    //    //public virtual async Task<T?> GetById(int id)
    //    //{
    //    //    var result = await _supabase.From<T>().Filter("id", = id).Single();
    //    //    return result;
    //    //}
    //}
}
