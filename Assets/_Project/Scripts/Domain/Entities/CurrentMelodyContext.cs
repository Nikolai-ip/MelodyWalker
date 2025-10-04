using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniRx;

namespace _Project.Scripts.Domain.Entities
{
    public class CurrentMelodyContext
    {
        private readonly List<Tuple<float, Note>> _currentNotes = new();
        public event Action OnNoteAdded;
        public ReactiveProperty<float> ErrorPercentage { get; } = new();

        public void AddNoteWithInterval(Tuple<float, Note> intervalAndNote)
        {
            _currentNotes.Add(intervalAndNote);
            OnNoteAdded?.Invoke();
        }
        

        public void ClearContext()
        {
            _currentNotes.Clear();
            ErrorPercentage.Value = 0;
        }

    }
}