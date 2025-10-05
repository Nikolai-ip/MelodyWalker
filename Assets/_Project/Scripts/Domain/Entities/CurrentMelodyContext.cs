using System;
using System.Collections.Generic;
using UniRx;

namespace _Project.Scripts.Domain.Entities
{
    public class CurrentMelodyContext
    {
        private readonly List<Tuple<float, Note>> _currentNotes = new();

        public List<Tuple<float, Note>> CurrentNotes => _currentNotes;
        public ReactiveProperty<float> ErrorPercentage { get; } = new();
        public Melody Melody { get; set; }
        public int CountOfPerformedTacts { get; set; }
        public void AddNoteWithInterval(Tuple<float, Note> intervalAndNote)
        {
            _currentNotes.Add(intervalAndNote);
        }

        public void ClearContext()
        {
            _currentNotes.Clear();
            ErrorPercentage.Value = 0;
            Melody = null;
        }

    }
}