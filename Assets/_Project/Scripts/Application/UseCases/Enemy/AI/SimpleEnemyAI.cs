using System;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Application.UseCases.Enemy.AI
{
    public class SimpleEnemyAI : BaseEnemyAI
    {
        [SerializeField] private PlayerZoneTrigger _zoneTrigger;
        public override Vector3 TargetPosition { get; protected set; }

        private IDisposable _timerSubscription;
        private Transform _targetTransform;

        [SerializeField] private float _timeBeforeLostTarget;

        private void OnEnable()
        {
            _zoneTrigger.ZoneEntered += StartFollowing;
            _zoneTrigger.ZoneExited += StartTimerToLost;
        }

        private void Update()
        {
            if (_targetTransform != null)
                UpdateTargetPos();
        }

        private void OnDisable()
        {
            _zoneTrigger.ZoneEntered -= StartFollowing;
            _zoneTrigger.ZoneExited -= StartTimerToLost;
        }

        private void StartTimerToLost(PlayerTag playerTag)
        {
            _timerSubscription = Observable
                .Timer(TimeSpan.FromSeconds(_timeBeforeLostTarget))
                .Subscribe(_ => ClearTargetPos());
        }
        private void UpdateTargetPos() => TargetPosition = _targetTransform.position;
        private void StartFollowing(PlayerTag obj)
        {
            _targetTransform = obj.transform;
            _timerSubscription?.Dispose();
        }

        public override void CleanUp() => ClearTargetPos();

        public void ClearTargetPos()
        {
            _targetTransform = null;
            TargetPosition = transform.position;
        }
    }
}