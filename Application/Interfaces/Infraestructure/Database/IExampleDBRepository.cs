using Models.Entities;

namespace Interfaces.Infraestructure.Database
{
    public interface IExampleDBRepository
    {
        Task DeleteExampleAsync(int id);
        Task InsertUpdateExampleAsync(DBExampleEntity category);
        Task<IEnumerable<DBExampleEntity>> SelectAllExamplesAsync();
        Task<IEnumerable<DBExampleEntity>> SelectExampleByIdAsync(int id);
    }
}