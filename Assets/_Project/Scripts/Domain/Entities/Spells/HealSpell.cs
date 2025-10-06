using System;
using _Project.Scripts.Domain.Entities.HealthSystem;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities.Spells
{
    public class PermanentHealSpell : ISpell
    {
        private IHealable _target;

        public event Action<ISpell> OnCompleted;

        public int HealAmount { get; set; } = 3;

        public void Apply(GameObject target, float errorPercent)
        {
            if (!target.TryGetComponent(out _target))
                throw new ArgumentException("No Healable component found");
            
            _target.Heal(Mathf.CeilToInt(HealAmount));
            
            OnCompleted?.Invoke(this);
        }

        private void CleanUp() => OnCompleted?.Invoke(this);

        public void Cancel() => CleanUp();
    }
    
    public class HealSpell : ISpell
    {
        private IDisposable _timerSubs;
        private float _healTime = 5f;
        private IHealable _target;

        public event Action<ISpell> OnCompleted;

        public int HealAmount { get; set; } = 1;

        public void Apply(GameObject target, float errorPercent)
        {
            if (!target.TryGetComponent(out _target))
                throw new ArgumentException("No Healable component found");
            
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