using System;
using _Project.Scripts.Domain.Entities.Spells;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Application.UseCases.SpellCasters
{
    public class SelfCaster : Caster
    {
        [SerializeField] private GameObject _player;
        
        [SerializeField] private GameObject _dashEffect;
        [SerializeField] private GameObject _healEffect;

        public override void Cast<TTarget>(ISpell spell, float errorPercent)
        {
            //todo: Error Percent
            if (!_player.TryGetComponent(out TTarget target))
                throw new ArgumentException($"{_player.name} has not {typeof(TTarget).Name} component!");
            
            spell.Apply(target.gameObject, errorPercent);

            if (spell is DashSpell)
            {
                Instantiate(_dashEffect, _player.transform.position, _player.transform.rotation);
            }
            if (spell is HealSpell)
            {
                Instantiate(_healEffect, _player.transform).transform.position = _player.transform.position;
            }
        }
    }
}