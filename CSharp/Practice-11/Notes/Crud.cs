using Microsoft.EntityFrameworkCore;

namespace Notes;

// Методы для работы с данными в БД
public class Crud
{
    public static async Task<User> Create(string text,)
    
    
    
    
    // NOTE
    
    // создает новый note и сохраняет его в БД.
    public static async Task<Note> Create(string text, DateTimeOffset createdAt, CancellationToken ct = default)
    {
        await using var db = new NotesContext();
        var note = new Note
        {
            Text = text,
            CreatedAt =  createdAt,
        };
        db.Notes.Add(note);
        await db.SaveChangesAsync(ct);
        return note;
    }
    
    // READ
    public static async Task<List<Note>> Read(string search, CancellationToken ct = default)
    {
        await using var db = new NotesContext();
        var result = await db.Notes
            .Where(x => EF.Functions.Like(x.Text, $"%{search}%"))
            .ToListAsync(ct);
        return result;
    }
    
    // READ по id
    public static async Task<Note?> Read(int id, CancellationToken ct = default)
    {
        await using var db = new NotesContext();
        return await db.Notes.FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    // Обновляет текст заметки
    public static async Task Update(Note note, string text, CancellationToken ct = default)
    {
        await using var db = new NotesContext();
        note.Text = text;
        db.Notes.Update(note);
        await db.SaveChangesAsync(ct);
    }
    
    // Delete
    public static async Task Delete(Note note, CancellationToken ct = default)
    {
        await using var db = new NotesContext();
        db.Notes.Remove(note);
        await db.SaveChangesAsync(ct);
    }
}