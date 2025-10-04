using System.Collections.Generic;
using UniRx;

namespace _Project.Scripts.Domain.Entities
{
    public class CurrentMelodyContext
    {
        public Dictionary<float, Note> CurrentNotesInterval { get; } = new();
        public ReactiveProperty<float> ErrorPercentage { get; } = new();
        public Melody CurrentMelody { get; set; }
    }
}