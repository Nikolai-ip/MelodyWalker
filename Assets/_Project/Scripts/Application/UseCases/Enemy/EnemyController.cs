using System;
using _Project.Scripts.Application.UseCases.Enemy.AI;
using UnityEngine;

namespace _Project.Scripts.Application.UseCases.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private BaseEnemyAI _enemyAI;
        [SerializeField] private Mover _mover;

        private void FixedUpdate() => _mover.MoveTo(_enemyAI.TargetPosition);
    }
}