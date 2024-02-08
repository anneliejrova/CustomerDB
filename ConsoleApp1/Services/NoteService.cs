
using ConsoleApp1.Entities;
using ConsoleApp1.Repositories;

namespace ConsoleApp1.Services;

internal class NoteService
{
    private readonly NoteRepository _noteRepository;

    public NoteService(NoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public NoteEntity CreateNote(string note)
    {
        var noteEntity = _noteRepository.Get(x => x.Note == note);
        noteEntity ??= _noteRepository.Create(new NoteEntity { Note = note });

        return noteEntity;
    }

    public NoteEntity GetNoteById(int id)
    {
        var noteEntit = _noteRepository.Get(x => x.Id == id);
        return noteEntit;
    }

    public IEnumerable<NoteEntity> GetAllNotes()
    {
        var notes = _noteRepository.GetAll();
        return notes;
    }

    public NoteEntity UpdateNote(NoteEntity noteEntity)
    {
        var updatedNoteEntity = _noteRepository.Update(x => x.Id == noteEntity.Id, noteEntity);
        return updatedNoteEntity;
    }

    public void DeleteNote(int id)
    {
        _noteRepository.Delete(x => x.Id == id);
    }
}
