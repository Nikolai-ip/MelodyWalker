using System;
using _Project.Scripts.Application.UseCases;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities.Spells
{
    public class DashSpell : ISpell<Mover>
    {
        public event Action<ISpell<Mover>> OnCompleted;

        private float _prevSpeed;
        private Mover _target;
        private float _dashTime = 0.05f;
        private IDisposable _timerSubs;

        public float Speed { get; set; } = 35f;

        public void Apply(Mover target, float errorPercent)
        {
            _target = target;
            
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