using System.Collections;
using _Project.Scripts.Domain.Entities.HealthSystem;
using UnityEngine;

namespace _Project.Scripts.Application.UseCases.Enemy
{
    public class PlayerDamager : MonoBehaviour
    {
        private Coroutine _coroutine;

        [SerializeField] private int _damage;

        private void OnCollisionEnter(Collision other)
        {
            if (_coroutine != null)
                return;
            
            if (!other.gameObject.TryGetComponent(out PlayerMoveController player))
                return;

            _coroutine = StartCoroutine(StartDamaging(player.GetComponentInChildren<IDamageable>()));
        }

        private void OnCollisionExit(Collision other)
        {
            if (_coroutine == null)
                return;
            
            if (!other.gameObject.TryGetComponent(out PlayerMoveController player))
                return;
            
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        private IEnumerator StartDamaging(IDamageable damageable)
        {
            var seconds = new WaitForSeconds(1f);
            while (true)
            {
                damageable.TakeDamage(_damage);
                yield return seconds;
            }
        }
    }
}