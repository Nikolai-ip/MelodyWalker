using UnityEngine;

namespace _Project.Scripts.Domain.Entities.DeathHandlers
{
    public class PlayerDeathHandler : DeathHandler
    {
        public override void Die()
        {
            Debug.LogWarning("PLAYER DIED!");
        }
    }
}