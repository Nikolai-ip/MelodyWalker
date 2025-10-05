using System;
using _Project.Scripts.Domain.Entities.HealthSystem;

namespace _Project.Scripts.Domain.Entities.Spells
{
    public class DamageSpell : ISpell<IDamageable>
    {
        public int DamageAmount { get; set; } = 2;

        public void Apply(IDamageable target)
        {
            target.TakeDamage(DamageAmount);
            OnCompleted?.Invoke(this);
        }

        public void Cancel() => OnCompleted?.Invoke(this);

        public event Action<ISpell<IDamageable>> OnCompleted;
    }
}