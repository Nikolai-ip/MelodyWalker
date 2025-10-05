using UnityEngine;

namespace _Project.Scripts.Domain.Entities.DeathHandlers
{
    public class EnemyDeathHandler : DeathHandler
    {
        public override void Die()
        {
            Debug.LogWarning("ENEMY DIED!");
        }
    }
}