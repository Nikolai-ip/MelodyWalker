using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities
{
    public class CurrentMelodyContext
    {
        private readonly List<Tuple<float, Note>> _currentNotes = new();

        public List<Tuple<float, Note>> CurrentNotes => _currentNotes;
        public ReactiveProperty<float> ErrorPercentage { get; } = new();
        public Melody Melody { get; set; }
        public int CountOfPerformedTacts { get; set; }
        public event Action OnContextCleared;
        private readonly int _maxNotes = 15;
        public bool HaveASpace => _currentNotes.Count < _maxNotes;
        
        public void AddNoteWithInterval(Tuple<float, Note> intervalAndNote)
        {
            _currentNotes.Add(intervalAndNote);
        }

        public void ClearContext()
        {
            _currentNotes.Clear();
            ErrorPercentage.Value = 0;
            Melody = null;
            OnContextCleared?.Invoke();
            Debug.Log("[CurrentMelodyContext] ClearContext");
        }

    }
}