using UnityEngine;

namespace _Project.Scripts.Application.UseCases.Enemy.AI
{
    public abstract class BaseEnemyAI : MonoBehaviour
    {
        public abstract Vector3 TargetPosition { get; protected set; }
        public abstract void CleanUp();
    }
}