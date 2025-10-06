using System;
using _Project.Scripts.Domain.Entities.HealthSystem;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace _Project.Scripts.Presentation
{
    public class HealthBar: MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Slider _slider;
        private IDisposable _sub;
        private void OnEnable()
        {
            _sub = _health.CurrentHealth.Subscribe(SetUI);
        }

        private void OnDisable()
        {
            _sub.Dispose();
        }

        private void SetUI(int hp)
        {
            _slider.value = (float)hp / _health.MaxHealth;
        }
    }
}