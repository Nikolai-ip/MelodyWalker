using UnityEngine;

namespace _Project.Scripts.Domain.Entities.DeathHandlers
{
    public abstract class DeathHandler : MonoBehaviour
    {
        public abstract void Die();
    }
}