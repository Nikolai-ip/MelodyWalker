using System.Collections.Generic;
using _Project.Scripts.Application.UseCases.Common;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Application.UseCases
{
    public class GameReseter : MonoBehaviour
    {
        private Vector3 _lastCheckPointPosition;

        [SerializeField] private Vector3 _spawnOffset;

        [SerializeField] private List<CheckPoint> _checkPoints = new();
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private DeathChecker _playerDeathChecker;

        private void OnEnable()
        {
            _checkPoints.ForEach(
                checkPoint => checkPoint
                    .Reached
                    .TakeUntilDisable(checkPoint.gameObject)
                    .TakeUntilDisable(this)
                    .Subscribe(
                        _ =>
                        {
                            _lastCheckPointPosition = checkPoint.Position;
                            Debug.Log(_lastCheckPointPosition);
                        })
                    .AddTo(this));
            
            _playerDeathChecker.IsDead 
                .TakeUntilDisable(this)
                .Where(isDead => isDead)
                .Subscribe(_ => ResetGame())
                .AddTo(this);
        }

        private void ResetGame()
        {
            SpawnPlayerOnLastCheckPoint();
            Debug.Log("GAME RESETED!");
        }

        private void SpawnPlayerOnLastCheckPoint()
        {
            _playerTransform.position = _lastCheckPointPosition + _spawnOffset;
        }
    }
}