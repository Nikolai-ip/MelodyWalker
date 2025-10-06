using _Project.Scripts.Application.DTOs;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Repositories;
using MessagePipe;
using UnityEngine;

namespace _Project.Scripts.Domain.Services
{
    public class MelodyReplacer
    {
        private readonly PlayerMelodyRepository _playerMelodyRepository;
        private readonly MelodyDefiner _melodyDefiner;
        private IPublisher<NewMelodyLearned> _onNewMelodyPublisher;

        public MelodyReplacer(PlayerMelodyRepository playerMelodyRepository, MelodyDefiner melodyDefiner, IPublisher<NewMelodyLearned> onNewMelodyPublisher)
        {
            _playerMelodyRepository = playerMelodyRepository;
            _melodyDefiner = melodyDefiner;
            _onNewMelodyPublisher = onNewMelodyPublisher;
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
            _onNewMelodyPublisher.Publish(new NewMelodyLearned(newMelodyNotes));
        }
    }
}