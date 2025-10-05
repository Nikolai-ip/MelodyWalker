using _Project.Scripts.Domain.Entities.Spells;
using _Project.Scripts.Domain.ValueObjects;
using _Project.Scripts.Infrastructure.Input;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Application.UseCases.SpellCasters
{
    public class SpellsTester : MonoBehaviour
    {
        private IInputService _inputService;
        [SerializeField] private Caster _caster;

        [Inject]
        private void Construct(IInputService inputService) => _inputService = inputService;

        private void Start()
        {
            _inputService.NotePressed += index =>
            {
                switch (index)
                {
                    case NoteIndex.Note1:
                        _caster.Cast(new HealSpell());
                        break;
                    
                    case NoteIndex.Note2:
                        _caster.Cast(new DamageSpell());
                        break;
                    
                }
            };
        }
    }
}