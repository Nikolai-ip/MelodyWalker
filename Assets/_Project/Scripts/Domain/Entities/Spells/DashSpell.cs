using System;
using _Project.Scripts.Application.UseCases;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities.Spells
{
    public class DashSpell : ISpell
    {
        public event Action<ISpell> OnCompleted;

        private float _prevSpeed;
        private Mover _target;
        private float _dashTime = 0.05f;
        private IDisposable _timerSubs;

        public float Speed { get; set; } = 35f;

        public void Apply(GameObject target, float errorPercent)
        {
            if (!target.TryGetComponent(out Mover targetComponent))
                throw new ArgumentException("No Healable component found");

            _target = targetComponent;
            
            _prevSpeed = _target.Speed;
            _target.Speed = Speed;
            
            _timerSubs = Observable
                .Timer(TimeSpan.FromSeconds(_dashTime))
                .Subscribe(_ => OnStop());
        }

        private void OnStop() => CleanUp();

        private void CleanUp()
        {
            _timerSubs.Dispose();
            _timerSubs = null;
                
            _target.Speed = _prevSpeed;
            _target = null;
            
            OnCompleted?.Invoke(this);
        }

        public void Cancel() => CleanUp();
    }
}