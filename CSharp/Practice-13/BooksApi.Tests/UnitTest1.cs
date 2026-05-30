using System.Net.Http.Json;
using System.Text.Json;
using BooksApi.Data;

namespace BooksApi.Tests;

public class BooksTests(ApiFixture fixture)
{
    
    // тест на возвращение createdbook POST
    [Fact]
    public async Task PostBook_Returns_CreatedBook()
    {
        var ct = TestContext.Current.CancellationToken;
        using var client = fixture.Api.CreateClient();
        
        // отправялем post запрос
        var res = await client.PostAsJsonAsync("/books", new
        {
            name = "ASP.NET Core 3",
            author = "Фримен Адам",
            releaseDate = "2021-01-01"
        }, ct);
        
        Assert.True(res.IsSuccessStatusCode, await res.Content.ReadAsStringAsync());
    }
    
    // GET получить по id
    [Fact]
    public async Task GetBook_Returns_Book()
    {
        var ct = TestContext.Current.CancellationToken;
        using var client = fixture.Api.CreateClient();
        
        // отправялем post запрос
        var postRes = await client.PostAsJsonAsync("/books", new
        {
            name = "ASP.NET Core 3",
            author = "Фримен Адам",
            releaseDate = "2021-01-01"
        }, ct);
        // get
        var created = await postRes.Content.ReadFromJsonAsync<JsonElement>(ct);
        var id = created.GetProperty("id").GetInt32();
        var res = await client.GetAsync($"/books/{id}", ct);
        
        Assert.True(res.IsSuccessStatusCode, await res.Content.ReadAsStringAsync());
    }
    
    // GET получить список книг
    [Fact]
    public async Task GetBooks_Returns_BooksList()
    {
        var ct = TestContext.Current.CancellationToken;
        using var client = fixture.Api.CreateClient();
    
        await client.PostAsJsonAsync("/books", new
        {
            name = "ASP.NET Core 3", 
            author = "Фримен Адам", 
            releaseDate = "2021-01-01"
        }, ct);
        
        var res = await client.GetAsync("/books", ct);
        Assert.True(res.IsSuccessStatusCode, await res.Content.ReadAsStringAsync());
    }
    
    // PUT обновить книгу
    [Fact]
    public async Task PutBook_Returns_UpdatedBook()
    {
        var ct = TestContext.Current.CancellationToken;
        using var client = fixture.Api.CreateClient();
    
        var postRes = await client.PostAsJsonAsync("/books", new 
            { 
                name = "ASP.NET Core 3", 
                author = "Фримен Адам", 
                releaseDate = "2021-01-01" 
            }, ct);
        
        var created = await postRes.Content.ReadFromJsonAsync<JsonElement>(ct);
        var id = created.GetProperty("id").GetInt32();
        var res = await client.PutAsJsonAsync($"/books/{id}", new
        {
            name = "Обновлённое название", 
            author = "Фримен Адам", 
            releaseDate = "2021-01-01"
        }, ct);
        
        Assert.True(res.IsSuccessStatusCode, await res.Content.ReadAsStringAsync());
    }
    
    // DELETE удалить книгу
    [Fact]
    public async Task DeleteBook_Returns_NoContent()
    {
        var ct = TestContext.Current.CancellationToken;
        using var client = fixture.Api.CreateClient();
    
        var postRes = await client.PostAsJsonAsync("/books", new
        {
            name = "ASP.NET Core 3", 
            author = "Фримен Адам", 
            releaseDate = "2021-01-01"
        }, ct);

        var created = await postRes.Content.ReadFromJsonAsync<JsonElement>(ct);
        var id = created.GetProperty("id").GetInt32();
        var res = await client.DeleteAsync($"/books/{id}", ct);
        
        Assert.True(res.IsSuccessStatusCode, await res.Content.ReadAsStringAsync());
    }
}   