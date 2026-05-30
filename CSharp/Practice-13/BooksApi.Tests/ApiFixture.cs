using BooksApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BooksApi.Tests;

public class ApiFixture : IAsyncLifetime
{
    public ApiFactory Api { get; } = new();

    public async ValueTask InitializeAsync()
    {
        await using var scope = Api.Services.CreateAsyncScope();
        var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
        await dataContext.Database.EnsureDeletedAsync();
        await dataContext.Database.MigrateAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await using var scope = Api.Services.CreateAsyncScope();
        await scope.ServiceProvider.GetRequiredService<DataContext>().Database.EnsureDeletedAsync();
    }
}

