using Client.ViewModels;

namespace Client.Repositories;

public interface IGeneralRepository<TEntity, TKey>
    where TEntity : class
{
    Task<ResponseListVM<TEntity>> Get();
    Task<ResponseViewModel<TEntity>> Get(TKey id);
    Task<ResponseMessageVM> Post(TEntity entity);
    Task<ResponseMessageVM> Put(TEntity entity, TKey id);
    Task<ResponseMessageVM> Delete(TKey id);
}
