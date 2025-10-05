using UnityEngine;

namespace _Project.Scripts.Domain.Entities.DeathHandlers
{
    public class EnemyDeathHandler : DeathHandler
    {
        [SerializeField] private GameObject _enemy;

        public override void Die() => Destroy(_enemy);
    }
}