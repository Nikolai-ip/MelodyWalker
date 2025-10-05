using System;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities.HealthSystem
{
    public class Health : MonoBehaviour, IHealth, IDamageable, IHealable
    {
        [SerializeField] private int _maxHealth;
        private ReactiveProperty<int> _currentHealth = new();

        public int MaxHealth => _maxHealth;
        
        public IReadOnlyReactiveProperty<int> CurrentHealth => _currentHealth;

        private void Awake()
        {
            _currentHealth.Value = MaxHealth;
            
            // #TODO Remove
            _currentHealth.Subscribe(_ => Debug.Log($"Current Health {gameObject.name}: {_currentHealth.Value}"));
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentException("Damage cannot be negative");
            
            _currentHealth.Value = Mathf.Clamp(CurrentHealth.Value - damage, 0, MaxHealth);
        }

        public void Heal(int healAmount)
        {
            TakeDamage(3);
            if (healAmount < 0)
                throw new ArgumentException("Heal points cannot be negative");
    
            _currentHealth.Value = Mathf.Clamp(CurrentHealth.Value + healAmount, 0, MaxHealth);
        }
    }

    public interface IHealable
    {
        void Heal(int healAmount);
    }

    public interface IDamageable
    {
        void TakeDamage(int damage);
    }
}