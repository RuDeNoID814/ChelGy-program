using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;

namespace BooksApi.Tests;

public class ApiFactory : WebApplicationFactory<Program>
{
    private SqliteConnection? _keepAlive;
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // с keepalive мы держим одно постоянное соединение открытм всё время при запуске тестов.
        // без него наше соединение закрвывалось и вся БД пропала при тесте
        _keepAlive = new SqliteConnection("DataSource=testdb;Mode=Memory;Cache=Shared");
        _keepAlive.Open();
        
        builder.ConfigureAppConfiguration(config =>
        {
            config.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:SQLite"] = "Data Source=testdb;Mode=Memory;Cache=Shared"
            });
        });
        base.ConfigureWebHost(builder);
    }

    protected override void Dispose(bool disposing)
    {
        _keepAlive?.Dispose();
        base.Dispose(disposing);
    }
}