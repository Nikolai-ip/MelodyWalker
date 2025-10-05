using System;
using _Project.Scripts.Application.UseCases.Enemy;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Application.UseCases
{
    public class CheckPoint : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private PlayerZoneTrigger _playerZoneTrigger;
        private Subject<Unit> _reached = new();

        public IObservable<Unit> Reached => _reached;
        public Vector3 Position => _spawnPoint.position;
        
        private void OnEnable() => _playerZoneTrigger.ZoneEntered += OnCheckPointReached;
        private void OnDisable() => _playerZoneTrigger.ZoneEntered -= OnCheckPointReached;

        private void OnCheckPointReached(PlayerTag obj)
        {
            _reached?.OnNext(Unit.Default);
            gameObject.SetActive(false);
        }
    }
}