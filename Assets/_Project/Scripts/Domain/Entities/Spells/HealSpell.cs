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
}