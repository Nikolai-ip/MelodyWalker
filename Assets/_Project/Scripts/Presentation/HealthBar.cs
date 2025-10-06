using System;
using _Project.Scripts.Domain.Entities.HealthSystem;
using UnityEngine;

namespace _Project.Scripts.Presentation
{
    public class HealthBar: MonoBehaviour
    {
        [SerializeField] private Health _health;
        private IDisposable _sub;
        private void OnEnable()
        {
            _sub = _health.CurrentHealth.Subscribe(SetUI);
        }

        private void SetUI(int hp)
        {
            
        }
    }
}