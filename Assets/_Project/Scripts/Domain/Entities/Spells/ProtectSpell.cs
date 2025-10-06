using System;
using _Project.Scripts.Domain.Entities.HealthSystem;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities.Spells
{
    public class ProtectSpell : ISpell
    {
        private IDisposable _timerSubs;
        private IDamageable _target;
        
        private ProtectionModifier _protectionModifier = new ProtectionModifier();
        
        public float ProtectionTime { get; set; } = 5;

        public event Action<ISpell> OnCompleted;

        public void Apply(GameObject target, float errorPercent)
        {
            if (!target.TryGetComponent(out IDamageable _target))
                throw new ArgumentException("No Healable component found");

            _protectionModifier.IncreaseFactor *= (1 - errorPercent);
            
            _target.AddModifier(_protectionModifier);
            
            _timerSubs = Observable
                .Timer(TimeSpan.FromSeconds(ProtectionTime))
                .Subscribe(_ => OnStop());
        }

        private void OnStop() => CleanUp();

        public void Cancel() => CleanUp();

        private void CleanUp()
        {
            _timerSubs.Dispose();
            _timerSubs = null;

            _target.RemoveModifier(_protectionModifier);
            _target = null;
            
            _protectionModifier.Reset();
            
            // #TODO Remove
            Debug.Log("Protect spell stopped!");
            
            OnCompleted?.Invoke(this);
        }
    }
}