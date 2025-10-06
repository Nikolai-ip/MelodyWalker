using System;
using _Project.Scripts.Domain.Entities.HealthSystem;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities.Spells
{
    public class DamageSpell : ISpell
    {
        public int DamageAmount { get; set; } = 2;

        public void Apply(GameObject target, float errorPercent)
        {
            if (!target.TryGetComponent(out IDamageable targetComponent))
                throw new ArgumentException("No Healable component found");
            
            int damage = Mathf.CeilToInt(DamageAmount * (1 - errorPercent));
            targetComponent.TakeDamage(damage);
            OnCompleted?.Invoke(this);
        }

        public void Cancel() => OnCompleted?.Invoke(this);

        public event Action<ISpell> OnCompleted;
    }
}