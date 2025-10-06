using System;
using _Project.Scripts.Application.UseCases.Enemy;
using _Project.Scripts.Application.UseCases.Enemy.AI;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Domain.Entities.Spells
{
    public class InvisibleSpell : ISpell
    {
        public event Action<ISpell> OnCompleted;

        public float Alpha = 0.3f;

        private float _prevSpeed;
        private InvisibleSpellData _target;
        private float _invisibleTime = 3f;
        private IDisposable _timerSubs;
        
        private readonly BaseEnemyAI[] _allEnemies;
        private SpriteRenderer _spriteRenderer;
        private Collider _playerCollider;

        public InvisibleSpell()
        {
            _allEnemies = Object.FindObjectsOfType<BaseEnemyAI>();
        }

        public void Apply(GameObject target, float errorPercent)
        {
            _spriteRenderer = target.GetComponent<SpriteRenderer>();
            _playerCollider = target.GetComponentInChildren<PlayerTag>().GetComponent<Collider>();

            var newColor = _spriteRenderer.color;
            newColor.a = Alpha;
            _spriteRenderer.color = newColor;

            _playerCollider.enabled = false;

            foreach (var baseEnemyAI in _allEnemies) 
                baseEnemyAI.CleanUp();

            _timerSubs = Observable
                .Timer(TimeSpan.FromSeconds(_invisibleTime))
                .Subscribe(_ => OnStop());
        }

        private void OnStop() => CleanUp();

        private void CleanUp()
        {
            _timerSubs.Dispose();
            _timerSubs = null;
                
            var newColor = _spriteRenderer.color;
            newColor.a = 1f;
            _spriteRenderer.color = newColor;

            _playerCollider.enabled = true;
            
            OnCompleted?.Invoke(this);
        }

        public void Cancel() => CleanUp();
    }
}