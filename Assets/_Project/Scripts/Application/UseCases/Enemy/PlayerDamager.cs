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
            if (!other.gameObject.TryGetComponent(out PlayerTag player))
                return;

            _coroutine = StartCoroutine(StartDamaging(player.GetComponent<IDamageable>()));
        }

        private void OnCollisionExit(Collision other)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
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