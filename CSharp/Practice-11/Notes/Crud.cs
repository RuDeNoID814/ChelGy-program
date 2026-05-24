using Microsoft.EntityFrameworkCore;

namespace Notes;

public class Crud
{
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
    
    
    
}