using System;
using System.Linq;
using System.Text;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Services;
using _Project.Scripts.Domain.ValueObjects;
using _Project.Scripts.Infrastructure.Input;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Application.UseCases
{
    public class MelodyContextWriter: IInitializable, IDisposable
    {
        private readonly IInputService _inputService;
        private readonly CurrentMelodyContext _currentMelodyContext;
        private readonly NotesBuffer _notesBuffer;
        private readonly MelodyDefiner _melodyDefiner;
        private readonly MelodyPercentageErrorCalculator _melodyPercentageErrorCalculator;
        private readonly TactsCounter _tactsCounter;

        public MelodyContextWriter(IInputService inputService, CurrentMelodyContext currentMelodyContext, NotesBuffer notesBuffer, MelodyDefiner melodyDefiner, MelodyPercentageErrorCalculator melodyPercentageErrorCalculator, TactsCounter tactsCounter)
        {
            _inputService = inputService;
            _currentMelodyContext = currentMelodyContext;
            _notesBuffer = notesBuffer;
            _melodyDefiner = melodyDefiner;
            _melodyPercentageErrorCalculator = melodyPercentageErrorCalculator;
            _tactsCounter = tactsCounter;
        }

        public void Initialize()
        {
            _inputService.NotePressed += WriteNote;
            _inputService.CastCancelled += ClearContext;
        }
        
        private void WriteNote(NoteIndex noteIndex)
        {
             Tuple<float, Note> intervalAndNote;
             if (!_notesBuffer.IsEmpty)
             {
                 intervalAndNote = _notesBuffer.GetIntervalAndNoteFromBuffer();
                 _currentMelodyContext.AddNoteWithInterval(intervalAndNote);
                 Debug.Log($"Write note {intervalAndNote.Item2.NoteIndex} with interval {intervalAndNote.Item1}");
                 var currentMelody = _currentMelodyContext.CurrentNotes
                     .Select(note => note.Item2).ToList();
                 
                 if (_melodyDefiner
                     .TryDefineMelodyByNoteList(currentMelody, out var melody))
                 {
                     _currentMelodyContext.Melody = melody;
                     _currentMelodyContext.ErrorPercentage.Value = _melodyPercentageErrorCalculator.CalcTactsErrorPercentage(melody.Tacts, _currentMelodyContext.CurrentNotes);
                     _currentMelodyContext.CountOfPerformedTacts =
                         _tactsCounter.DetectPerformedTacts(currentMelody, melody);
                     Debug.Log("Found melody " + DebugMelody(melody));
                     Debug.Log("Error percent is" + _currentMelodyContext.ErrorPercentage.Value);
                     Debug.Log("Performed tacts " + _currentMelodyContext.CountOfPerformedTacts);
                 }
                 else
                 {
                     Debug.Log("FailedToFindMelody");
                 }
             }
             _notesBuffer.AddNoteIndexToBuffer((int)noteIndex);
        }

        private string DebugMelody(Melody foundMelody)
        {
            StringBuilder result = new();
            foreach (var tact in foundMelody.Tacts)
            {
                foreach (var note in tact.ReferenceNoteIntervals)
                {
                    result.Append(note.Item2.NoteIndex);
                    result.Append(" ");
                }
            }
            return result.ToString();
        }

        private void ClearContext()
        {
            _currentMelodyContext.ClearContext();
            _notesBuffer.ClearBuffer();
            Debug.Log("Clearing context");
        }

        public void Dispose()
        {
            _inputService.NotePressed -= WriteNote;
            _inputService.CastCancelled -= ClearContext;
        }
    }
}