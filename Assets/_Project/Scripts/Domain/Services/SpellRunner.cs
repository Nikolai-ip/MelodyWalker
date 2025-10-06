using System;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Repositories;
using _Project.Scripts.Domain.Rules;
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
        private CalcMelodyErrorsRule _calcMelodyErrorsRule;
        private NotesBuffer _notesBuffer;
        public event Action OnSpellCastFailed;
        public event Action<Melody> OnMelodySpellCastSuccess;

        public SpellRunner(CurrentMelodyContext currentMelodyContext, IInputService inputService, SpellDataRepository spellDataRepository, CalcMelodyErrorsRule calcMelodyErrorsRule, NotesBuffer notesBuffer)
        {
            _currentMelodyContext = currentMelodyContext;
            _inputService = inputService;
            _spellDataRepository = spellDataRepository;
            _calcMelodyErrorsRule = calcMelodyErrorsRule;
            _notesBuffer = notesBuffer;
        }

        public void Initialize()
        {
            _inputService.CastApplied += RunCurrentSpell;
        }

        private void RunCurrentSpell()
        {
            if (_currentMelodyContext.ErrorPercentage.Value < _calcMelodyErrorsRule.AllowedErrorPercentage 
                 && _spellDataRepository.Spells.TryGetValue(_currentMelodyContext.Melody, out var abilities))
            {
                abilities[_currentMelodyContext.CountOfPerformedTacts].Invoke(_currentMelodyContext.ErrorPercentage.Value);
                OnMelodySpellCastSuccess?.Invoke(_currentMelodyContext.Melody);
            }
            else
            {
                Debug.LogWarning("[SpellRunner] (RunCurrentSpell) Failed to find spell for current melody");
                OnSpellCastFailed?.Invoke();
                _currentMelodyContext.ClearContext();
                _notesBuffer.ClearBuffer();
            }

        }

        public void Dispose()
        {
            _inputService.CastApplied -= RunCurrentSpell;
        }
    }
}