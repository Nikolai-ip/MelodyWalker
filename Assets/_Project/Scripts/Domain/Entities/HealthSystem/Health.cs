using System;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities.HealthSystem
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] private int _maxHealth; 
        
        public int MaxHealth => _maxHealth;
        public ReactiveProperty<int> CurrentHealth { get; }

        private void Awake() => CurrentHealth.Value = MaxHealth;

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentException("Damage cannot be negative");
            
            CurrentHealth.Value = Mathf.Clamp(CurrentHealth.Value - damage, 0, MaxHealth);
        }
    }
}