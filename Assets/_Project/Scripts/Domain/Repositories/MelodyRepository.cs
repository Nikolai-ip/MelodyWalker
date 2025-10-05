using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Services;

namespace _Project.Scripts.Domain.Repositories
{
    public class MelodyRepository
    {
        public List<Melody> Melodies { get; }
        public List<Tuple<ulong, Melody>> HashedMelodies { get; } = new();

        public MelodyRepository(List<Melody> melodies)
        {
            Melodies = melodies;
            foreach (var melody in melodies)
            {
                var noteIndexesList = MelodyConverterUtility.ConvertTactsToNoteList(melody.Tacts).Select(note=>note.NoteIndex);
                ulong hash = SimHash.Compute(noteIndexesList);
                HashedMelodies.Add(new Tuple<ulong, Melody>(hash, melody));
            }
        }
    }
}