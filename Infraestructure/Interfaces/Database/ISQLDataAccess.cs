namespace Interfaces.DBAccess
{
    public interface ISQLDataAccess
    {
        Task DeleteAsync(string Query, object? Parametros = null);
        Task InsertUpdateAsync<T>(string Query, T data);
        Task<IEnumerable<T>> SelectAsync<T>(string query, object? parametros = null);
    }
}