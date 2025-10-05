using System;
using _Project.Scripts.Domain.Entities.HealthSystem;

namespace _Project.Scripts.Domain.Entities.Spells
{
    public class HealSpell : ISpell<IHealable>
    {
        public event Action<ISpell<IHealable>> OnCompleted;

        public int HealAmount { get; set; } = 1;

        public void Apply(IHealable target)
        {
            target.Heal(HealAmount);
            OnCompleted?.Invoke(this);
        }
        public void Cancel() => OnCompleted?.Invoke(this);
    }
    
    public class DamageSpell : ISpell<IDamageable>
    {
        public int DamageAmount { get; set; } = 1;

        public void Apply(IDamageable target)
        {
            target.TakeDamage(DamageAmount);
            OnCompleted?.Invoke(this);
        }

        public void Cancel() => OnCompleted?.Invoke(this);

        public event Action<ISpell<IDamageable>> OnCompleted;
    }
}