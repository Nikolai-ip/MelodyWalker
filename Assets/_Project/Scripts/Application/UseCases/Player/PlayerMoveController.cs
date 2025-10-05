using _Project.Scripts.Application.UseCases.Player;
using UnityEngine;

namespace _Project.Scripts.Application.UseCases
{
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private MouseTargetCalculator _targetCalculator;

        private void Update() => _mover.MoveTo(_targetCalculator.Target);
    }
}