using System;
using _Project.Scripts.Application.UseCases.Common;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Domain.Entities.DeathHandlers
{
    public abstract class DeathHandler : MonoBehaviour
    {
        private IDisposable _subsDisposable;

        [SerializeField] private DeathChecker _deathChecker;

        private void OnEnable()
        {
            _subsDisposable = _deathChecker.IsDead
                .Where(isDead => isDead)
                .Subscribe(_ => Die());
        }

        private void OnDisable() => _subsDisposable?.Dispose();

        public abstract void Die();
    }
}