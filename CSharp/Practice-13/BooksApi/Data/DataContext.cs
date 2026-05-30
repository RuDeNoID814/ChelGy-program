using Microsoft.EntityFrameworkCore;

namespace BooksApi.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();
}