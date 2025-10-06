using System;
using _Project.Scripts.Application.UseCases;
using _Project.Scripts.Domain.Entities.HealthSystem;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities.Spells
{
    public class SlowerSpell : ISpell
    {
        private IDisposable _timerSubs;
        private float _slowingTime = 3f;
        private Mover _target;
        private float SlowingSpeed = 2f;
        private float _prevSpeed;

        public event Action<ISpell> OnCompleted;

        public void Apply(GameObject target, float errorPercent)
        {
            if (!target.TryGetComponent(out _target))
                throw new ArgumentException("No Healable component found");
            
            OnCompleted?.Invoke(this);

            _prevSpeed = _target.Speed; 
            _target.Speed = (SlowingSpeed);
            
            _timerSubs = Observable
                .Timer(TimeSpan.FromSeconds(_slowingTime * (1f - errorPercent)))
                .Subscribe(_ => OnStop());
        }

        private void OnStop() => CleanUp();

        private void CleanUp()
        {
            _timerSubs.Dispose();
            _timerSubs = null;

            _target.Speed = _prevSpeed;
            _target = null;
            
            Debug.Log("END SLOWING");
            
            OnCompleted?.Invoke(this);
        }

        public void Cancel() => CleanUp();
    }
}