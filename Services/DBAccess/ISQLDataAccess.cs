namespace Services.BusinessLogic
{
    public interface ISQLDataAccess
    {
        List<T> Select<T>(string query, object? parametros = null);
    }
}