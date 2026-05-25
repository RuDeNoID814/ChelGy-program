namespace Notes.Tests;

// Тесты для Crud
//



public class UnitTest1
{
    
    // тест для Create.
    // в sqlite id начинается с 1. Проверка на так называемое создание, что он наш note создается
    // на > 0
    [Fact]
    public async Task Check_NotesCreate_ReturnsTrue()
    {
        await using var db = new NotesContext();
        await db.Database.EnsureDeletedAsync();
        await db.Database.EnsureCreatedAsync();
        var note = await Crud.Create("tested note", DateTimeOffset.Now);
        Assert.NotNull(note);
        Assert.True(note.Id > 0);
    }
    
    // Тест для Read string
    [Fact]
    public async Task Read_Notes_String()
    {
        await using var db = new NotesContext();
        await db.Database.EnsureDeletedAsync();
        await db.Database.EnsureCreatedAsync();
        var note = await Crud.Create("tested note", DateTimeOffset.Now);
        var result = await Crud.Read("tested note");
        Assert.NotNull(result);
    }
    
    // Тест для Read int
    [Fact]
    public async Task Read_Notes_Int()
    {
        await using var db = new NotesContext();
        await db.Database.EnsureDeletedAsync();
        await db.Database.EnsureCreatedAsync();
        var note = await Crud.Create("tested note", DateTimeOffset.Now);
        var result = await Crud.Read(note.Id);
        Assert.NotNull(result);
    }
    
    // Update
    [Fact]
    public async Task Check_NotesUpdate_ReturnsTrue()
    {
        await using var db = new NotesContext();
        await db.Database.EnsureDeletedAsync();
        await db.Database.EnsureCreatedAsync();
        var note = await Crud.Create("tested note", DateTimeOffset.Now);
        await Crud.Update(note, "update tested");
        Assert.Equal("update tested", note.Text);
    }
    
    // Delete
    [Fact]
    public async Task Check_NotesDelete_ReturnsTrue()
    {
        await using var db = new NotesContext();
        await db.Database.EnsureDeletedAsync();
        await db.Database.EnsureCreatedAsync();
        var note = await Crud.Create("tested note", DateTimeOffset.Now);
        await Crud.Delete(note);
        var result = await Crud.Read("tested note");
        Assert.Empty(result);
    }
}