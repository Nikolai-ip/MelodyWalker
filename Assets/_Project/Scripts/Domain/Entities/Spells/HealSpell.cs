using System;
using _Project.Scripts.Domain.Entities.HealthSystem;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities.Spells
{
    public class HealSpell : ISpell<IHealable>
    {
        public event Action<ISpell<IHealable>> OnCompleted;

        public int HealAmount { get; set; } = 3;

        public void Apply(IHealable target, float errorPercent)
        {
            target.Heal(Mathf.CeilToInt(HealAmount * (1 - errorPercent)));
            OnCompleted?.Invoke(this);
        }
        public void Cancel() => OnCompleted?.Invoke(this);
    }
}