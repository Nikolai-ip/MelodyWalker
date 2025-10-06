using System;
using _Project.Scripts.Domain.Entities.HealthSystem;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities.Spells
{
    public class HealSpell : ISpell<IHealable>
    {
        private IDisposable _timerSubs;
        private float _healTime = 5f;
        private IHealable _target;

        public event Action<ISpell<IHealable>> OnCompleted;

        public int HealAmount { get; set; } = 1;

        public void Apply(IHealable target, float errorPercent)
        {
            _target = target;
            
            OnCompleted?.Invoke(this);

            OnTick();
            
            _timerSubs = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .TakeUntil(Observable.Timer(TimeSpan.FromSeconds(_healTime * (1 - errorPercent))))
                .Subscribe(_ => OnTick(), exception => Debug.LogException(exception), OnStop);
        }

        private void OnTick() => _target.Heal(Mathf.CeilToInt(HealAmount));

        private void OnStop() => CleanUp();

        private void CleanUp()
        {
            _timerSubs.Dispose();
            _timerSubs = null;
            
            Debug.Log("END HEAL");
            
            OnCompleted?.Invoke(this);
        }

        public void Cancel() => CleanUp();
    }
}