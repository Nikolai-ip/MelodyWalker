using System;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities
{
    public interface ISpellBase
    {
        
    }
    
    public interface ISpell<in TTarget> : ISpellBase
    {
        void Apply(TTarget target);
        void Cancel();
        event Action<ISpell<TTarget>> OnCompleted;
    }
}