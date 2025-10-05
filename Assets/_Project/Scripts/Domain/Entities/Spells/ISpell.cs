using System;

namespace _Project.Scripts.Domain.Entities.Spells
{
    public interface ISpell<in TTarget>
    {
        void Apply(TTarget target);
        void Cancel();
        event Action<ISpell<TTarget>> OnCompleted;
    }
}