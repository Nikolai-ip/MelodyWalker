using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        public void AddNoteWithInterval(Tuple<float, Note> intervalAndNote)
        {
            _currentNotes.Add(intervalAndNote);
            Debug.Log($"Write note {intervalAndNote.Item2.NoteIndex} with interval {intervalAndNote.Item1}");
        }
        

        public void ClearContext()
        {
            _currentNotes.Clear();
            ErrorPercentage.Value = 0;
        }

    }
}