namespace Infrastructure.EF;

public class DBContextProvider
{
    private readonly IConnectionStringProvider _connectionStringProvider;

    public DBContextProvider(IConnectionStringProvider connectionStringProvider)
    {
        _connectionStringProvider = connectionStringProvider;
    }

    public DBContext NewContext()
    {
        return new DBContext(_connectionStringProvider);
    }
}