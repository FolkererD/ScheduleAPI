using Infrastructure;

namespace Api;

public class ConnectionStringProvider : IConnectionStringProvider
{
    private readonly IConfiguration _configuration;

    public ConnectionStringProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetConnectionString(string key)
    {
        return _configuration.GetConnectionString(key);
    }
}