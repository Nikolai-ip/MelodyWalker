using System;
using _Project.Scripts.Domain.Entities.HealthSystem;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities.Spells
{
    public class DamageSpell : ISpell<IDamageable>
    {
        public int DamageAmount { get; set; } = 2;

        public void Apply(IDamageable target, float errorPercent)
        {
            int damage = Mathf.CeilToInt(DamageAmount * (1 - errorPercent));
            target.TakeDamage(damage);
            OnCompleted?.Invoke(this);
        }

        public void Cancel() => OnCompleted?.Invoke(this);

        public event Action<ISpell<IDamageable>> OnCompleted;
    }
}