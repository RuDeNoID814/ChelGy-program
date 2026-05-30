using Microsoft.EntityFrameworkCore;

namespace Notes;

// Методы для работы с данными в БД
public class Crud
{
    
    
    // USER
    
    // Create - создание пользователя
    public static async Task<User> CreateUser(string name, CancellationToken ct = default)
    {
        await using var db = new NotesContext();
        var user = new User{Name = name};
        db.Users.Add(user);
        await db.SaveChangesAsync(ct);
        return user;
    }
    
    // Read - поиск по id
    public static async Task<User?> ReadUser(int id, CancellationToken ct = default)
    {
        await using var db = new NotesContext();
        return await db.Users.FirstOrDefaultAsync(x => x.Id == id, ct);
    }
    
    // Update - обновить имя
    public static async Task UpdateUser(User user, CancellationToken ct = default)
    {
        await using var db = new NotesContext();
        db.Users.Update(user);
        await db.SaveChangesAsync(ct);
    }
    
    // Delete - прожать крестом
    public static async Task DeleteUser(User user, CancellationToken ct = default)
    {
        await using var db = new NotesContext();
        db.Users.Remove(user);
        await db.SaveChangesAsync(ct);
    }
    
    
    // NOTE
    
    // создает новый note и сохраняет его в БД.
    public static async Task<Note> CreateNote(string text, DateTimeOffset createdAt, int userId, CancellationToken ct = default)
    {
        await using var db = new NotesContext();
        var note = new Note
        {
            Text = text,
            CreatedAt =  createdAt,
            UserId = userId
        };
        db.Notes.Add(note);
        await db.SaveChangesAsync(ct);
        return note;
    }
    
    // READ
    public static async Task<List<Note>> ReadNotes(string search, CancellationToken ct = default)
    {
        await using var db = new NotesContext();
        var result = await db.Notes
            .Where(x => EF.Functions.Like(x.Text, $"%{search}%"))
            .ToListAsync(ct);
        return result;
    }
    
    // READ по id
    public static async Task<Note?> ReadNote(int id, CancellationToken ct = default)
    {
        await using var db = new NotesContext();
        return await db.Notes.FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    // Обновляет текст заметки
    public static async Task UpdateNote(Note note, string text, CancellationToken ct = default)
    {
        await using var db = new NotesContext();
        note.Text = text;
        db.Notes.Update(note);
        await db.SaveChangesAsync(ct);
    }
    
    // Delete
    public static async Task DeleteNote(Note note, CancellationToken ct = default)
    {
        await using var db = new NotesContext();
        db.Notes.Remove(note);
        await db.SaveChangesAsync(ct);
    }
    
    // получение всех заметок конкретного пользователя
    public static async Task<List<Note>> GetNotesByUser(int userId, CancellationToken ct = default)
    {
        await using var db = new NotesContext();
        return await db.Notes
            .Where(x => x.UserId == userId)
            .ToListAsync(ct);
    }
}