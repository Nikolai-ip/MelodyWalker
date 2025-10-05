using System;
using UniRx;

namespace _Project.Scripts.Domain.Entities.HealthSystem
{
    public interface IHealth
    {
        int MaxHealth { get; }
        IReadOnlyReactiveProperty<int> CurrentHealth { get; }
    }
}