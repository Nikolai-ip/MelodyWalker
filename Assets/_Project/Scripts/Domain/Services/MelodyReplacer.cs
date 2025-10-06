using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Repositories;
using UnityEngine;

namespace _Project.Scripts.Domain.Services
{
    public class MelodyReplacer
    {
        private readonly PlayerMelodyRepository _playerMelodyRepository;
        private readonly MelodyDefiner _melodyDefiner;

        public MelodyReplacer(PlayerMelodyRepository playerMelodyRepository, MelodyDefiner melodyDefiner)
        {
            _playerMelodyRepository = playerMelodyRepository;
            _melodyDefiner = melodyDefiner;
        }

        public void ReplaceOrAddMelody(Melody newMelody)
        {
            var newMelodyNotes = MelodyConverterUtility.ConvertTactsToNoteList(newMelody.Tacts);
            if (_melodyDefiner.TryDefineMelodyByNoteList(newMelodyNotes, out var foundMelody))
            {
                int index = _playerMelodyRepository.Melodies.IndexOf(foundMelody);
                _playerMelodyRepository.Melodies.RemoveAt(index);
                _playerMelodyRepository.Melodies.Insert(index, newMelody);
                Debug.Log("[MelodyReplacer] (Replace melody)");
            }
            else
            {
                _playerMelodyRepository.Melodies.Add(newMelody);
                Debug.Log("[MelodyReplacer] (Add new melody)");
            }
        }
    }
}