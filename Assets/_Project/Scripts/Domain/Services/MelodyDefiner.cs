using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Repositories;

namespace _Project.Scripts.Domain.Services
{
    public class MelodyDefiner
    {
        private readonly MelodyRepository _melodyRepository;

        public MelodyDefiner(MelodyRepository melodyRepository)
        {
            _melodyRepository = melodyRepository;
        }
        public bool TryDefineMelodyByTacts(List<Note> currentMelody, out Melody foundMelody)
        {
            foundMelody = null;
            var currentIndexes = currentMelody.Select(n => n.NoteIndex).ToList();

            foreach (var melody in _melodyRepository.Melodies)
            {
                var melodyIndexes = MelodyConverterUtility
                    .ConvertTactsToNoteList(melody.Tacts)
                    .Select(n => n.NoteIndex);

                if (IsPrefix(currentIndexes, melodyIndexes))
                {
                    foundMelody = melody;
                    return true;
                }
            }

            return false;
        }

        private bool IsPrefix(List<int> prefix, IEnumerable<int> full)
        {
            for (int i = 0; i < prefix.Count; i++)
            {
                if (prefix[i] != full.ElementAt(i))
                    return false;
            }

            return true;
        }
        
    }
}