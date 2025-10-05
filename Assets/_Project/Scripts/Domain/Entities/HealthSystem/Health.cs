using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities.HealthSystem
{
    public class Health : MonoBehaviour, IHealth, IDamageable, IHealable
    {
        private ReactiveProperty<int> _currentHealth = new();
        private bool _isProtected;
        private List<Modifier<int>> _damageModifiers = new();

        [SerializeField] private int _maxHealth;

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

            foreach (Modifier<int> damageModifier in _damageModifiers) 
                damage = damageModifier.Modify(damage);
            
            _currentHealth.Value = Mathf.Clamp(CurrentHealth.Value - damage, 0, MaxHealth);
        }

        public void AddModifier(Modifier<int> damageModifier) => _damageModifiers.Add(damageModifier);
        public void RemoveModifier(Modifier<int> damageModifier) => _damageModifiers.Remove(damageModifier);

        public void Heal(int healAmount)
        {
            if (healAmount < 0)
                throw new ArgumentException("Heal points cannot be negative");

            _currentHealth.Value = Mathf.Clamp(CurrentHealth.Value + healAmount, 0, MaxHealth);
        }
    }

    public interface IHealable
    {
        void Heal(int healAmount);
    }

    public interface IModifyable<T>
    {
        void AddModifier(Modifier<T> damageModifier);
        public void RemoveModifier(Modifier<T> damageModifier);
    }
    
    public interface IDamageable : IModifyable<int>
    {
        void TakeDamage(int damage);
    }

    public abstract class Modifier<T>
    {
        public abstract T Modify(T value);
    }

    public class ProtectionModifier : Modifier<int>
    {
        private float _increaseFactor = 0.5f;

        public override int Modify(int value) => Mathf.CeilToInt(value * _increaseFactor);
    }
}