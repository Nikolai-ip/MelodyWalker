using System;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Services;
using _Project.Scripts.Domain.ValueObjects;
using _Project.Scripts.Infrastructure.Input;
using Zenject;

namespace _Project.Scripts.Application.UseCases
{
    public class MelodyWriter: IInitializable, IDisposable
    {
        private readonly IInputService _inputService;
        private readonly CurrentMelodyContext _currentMelodyContext;
        private readonly NotesBuffer _notesBuffer;

        public MelodyWriter(IInputService inputService, CurrentMelodyContext currentMelodyContext, NotesBuffer notesBuffer)
        {
            _inputService = inputService;
            _currentMelodyContext = currentMelodyContext;
            _notesBuffer = notesBuffer;
        }

        public void Initialize()
        {
            _inputService.NotePressed += WriteNote;
            _inputService.CastCancelled += ClearContext;
        }
        
        private void WriteNote(NoteIndex noteIndex)
        {
             Tuple<float, Note> intervalAndNote = !_notesBuffer.IsEmpty ?
                _notesBuffer.GetIntervalAndNoteFromBuffer() 
                : new Tuple<float, Note>(0, new Note((int)noteIndex));
             
            _currentMelodyContext.AddNoteWithInterval(intervalAndNote);
            _notesBuffer.AddNoteIndexToBuffer((int)noteIndex);
        }
        
        private void ClearContext()
        {
            _currentMelodyContext.ClearContext();
        }

        public void Dispose()
        {
            _inputService.NotePressed -= WriteNote;
            _inputService.CastCancelled -= ClearContext;
        }
    }
}