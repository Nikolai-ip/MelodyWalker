using System;
using _Project.Scripts.Application.UseCases;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities.Spells
{
    public class InvisibleSpell : ISpell<InvisibleSpellData>
    {
        public event Action<ISpell<InvisibleSpellData>> OnCompleted;

        public float Alpha = 0.3f;

        private float _prevSpeed;
        private InvisibleSpellData _target;
        private float _invisibleTime = 0.05f;
        private IDisposable _timerSubs;

        public void Apply(InvisibleSpellData target, float errorPercent)
        {
            _target = target;

            var newColor = target.SpriteRenderer.color;
            newColor.a = Alpha;
            
            target.SpriteRenderer.color = newColor;
            // target.
            
            // _target.Speed = Speed;
            
            // _targetData
            
                _timerSubs = Observable
                    .Timer(TimeSpan.FromSeconds(_invisibleTime))
                    .Subscribe(_ => OnStop());
        }

        private void OnStop() => CleanUp();

        private void CleanUp()
        {
            _timerSubs.Dispose();
            _timerSubs = null;
                
            // _target.Speed = _prevSpeed;
            _target = null;
            
            OnCompleted?.Invoke(this);
        }

        public void Cancel() => CleanUp();
    }
}