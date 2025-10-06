using System;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities.Spells
{
    public interface ISpell
    {
        void Apply(GameObject target, float errorPercent);
        void Cancel();
        event Action<ISpell> OnCompleted;
    }
}