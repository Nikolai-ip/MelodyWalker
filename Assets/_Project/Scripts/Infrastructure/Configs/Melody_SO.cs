using System;
using System.Collections.Generic;
using _Project.Scripts.Domain.Entities;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "StaticData/Melody", fileName = "Melody")]
    public class Melody_SO: ScriptableObject
    {
        [field: SerializeField] public List<TactSerializable> Tacts { get; private set; }

        public Melody GetMelody()
        {
            List<Tact> tacts = new();
            foreach (var tact in Tacts)
            {
                List<Tuple<float, Note>> notes = new();
                foreach (var note in tact.Notes)
                {
                    notes.Add(new Tuple<float, Note>(note.Interval, new Note(note.NoteIndex)));
                }
                tacts.Add(new Tact(notes));
            }
            return new Melody(tacts);
        }
    }
    [Serializable]
    public class TactSerializable
    {
        [field: SerializeField] public List<IntervalNotePair> Notes { get; private set; }
    }
    
    [Serializable]
    public class IntervalNotePair
    {
        [field: SerializeField] public float Interval { get; private set; }
        [field: SerializeField] public int NoteIndex { get; private set; }
    }
}