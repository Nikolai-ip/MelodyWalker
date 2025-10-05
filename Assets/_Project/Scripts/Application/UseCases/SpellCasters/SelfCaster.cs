using System;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Entities.Spells;
using UnityEngine;

namespace _Project.Scripts.Application.UseCases.SpellCasters
{
    public class SelfCaster : Caster
    {
        [SerializeField] private GameObject _player;

        public override void Cast<TTarget>(ISpell<TTarget> spell, float errorPercent)
        {
            //todo: Error Percent
            if (!_player.TryGetComponent(out TTarget target))
                throw new ArgumentException($"{_player.name} has not {typeof(TTarget).Name} component!");
            
            spell.Apply(target);
        }
    }
}