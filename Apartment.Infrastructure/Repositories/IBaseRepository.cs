namespace Apartment.Infrastructure.Repositories;

public interface IBaseRepository<TModel> where TModel : class
{
    public ValueTask<bool> CreateAsync(TModel model);
    public ValueTask<bool> UpdateAsync(int id, TModel model);
    public ValueTask<bool> DeleteAsync(int id);
    public ValueTask<IList<TModel>> GetAllAsync();
    public ValueTask<TModel> GetByIdAsync(int id);
    public ValueTask<int> GetCountAsync();
}
