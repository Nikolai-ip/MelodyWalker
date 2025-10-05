using System;
using _Project.Scripts.Domain.Entities.HealthSystem;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Application.UseCases.Common
{
    public class DeathChecker : MonoBehaviour
    {
        [SerializeField] private Health _health;
        
        private ReactiveProperty<bool> _isDead = new ReactiveProperty<bool>(false);
        
        public IReadOnlyReactiveProperty<bool> IsDead => _isDead;
        
        private IDisposable _subsDisposable;

        private void OnEnable()
        {
            _subsDisposable = _health.CurrentHealth
                .TakeUntilDisable(this)
                .Skip(1)
                .Subscribe(_ => CheckDeath())
                .AddTo(this);
        }

        private void CheckDeath()
        {
            if (_health.CurrentHealth.Value > 0)
                return;
            
            _isDead.Value = true;
            Debug.Log($"{gameObject.name} is dead!");
        }
    }
}