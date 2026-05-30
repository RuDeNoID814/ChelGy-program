namespace Notes;

// Модель для БД
public class Note
{
    public int Id { get; set; }
    public required string Text { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    
    // связываем note с user
    
    public int UserId { get; set; }
    public User? User { get; set; }
}