using System;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Repositories;
using _Project.Scripts.Infrastructure.Input;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Domain.Services
{
    public class SpellRunner: IInitializable, IDisposable
    {
        private readonly CurrentMelodyContext _currentMelodyContext;
        private readonly IInputService _inputService;
        private readonly SpellDataRepository _spellDataRepository;

        public SpellRunner(CurrentMelodyContext currentMelodyContext, IInputService inputService, SpellDataRepository spellDataRepository)
        {
            _currentMelodyContext = currentMelodyContext;
            _inputService = inputService;
            _spellDataRepository = spellDataRepository;
        }

        public void Initialize()
        {
            _inputService.CastApplied += RunCurrentSpell;
        }

        private void RunCurrentSpell()
        {
            if (_spellDataRepository.Spells.TryGetValue(_currentMelodyContext.Melody, out var abilities))
            {
                abilities[_currentMelodyContext.CountOfPerformedTacts].Invoke(_currentMelodyContext.ErrorPercentage.Value);
            }
            else
            {
                Debug.LogWarning("[SpellRunner] (RunCurrentSpell) Failed to find spell for current melody");
            }

        }

        public void Dispose()
        {
            _inputService.CastApplied -= RunCurrentSpell;
        }
    }
}