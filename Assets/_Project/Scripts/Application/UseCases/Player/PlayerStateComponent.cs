using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Application.UseCases.Enemy.AI;
using _Project.Scripts.Application.Utilities;
using MessagePipe;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Application.UseCases.Player
{
    public class PlayerStateComponent: IInitializable, IDisposable
    {
        private readonly ITriggerEventInvoker<BaseEnemyAI> _enemyTriggerInvoker;
        private readonly HashSet<BaseEnemyAI> _enemies = new();
        private readonly ReactiveProperty<PlayerWorldState> _playerWorldStatePublisher;
        private IPublisher<PlayerWorldState> _playerWorldStatePublisherPublisher;
        private readonly IDisposable _subscription;

        public PlayerStateComponent(ITriggerEventInvoker<BaseEnemyAI> enemyTriggerInvoker, IPublisher<PlayerWorldState> playerWorldStatePublisherPublisher)
        {
            _enemyTriggerInvoker = enemyTriggerInvoker;
            _playerWorldStatePublisherPublisher = playerWorldStatePublisherPublisher;
            _playerWorldStatePublisher = new();
            _subscription = _playerWorldStatePublisher.Subscribe(PublishState);
        }

        public void Initialize()
        {
            _enemyTriggerInvoker.OnTriggerEnterEvent += AddEnemyToCollection;
            _enemyTriggerInvoker.OnTriggerExitEvent += RemoveEnemyFromCollection;
        }

        private void PublishState(PlayerWorldState state)
            => _playerWorldStatePublisherPublisher.Publish(state);

        private void RemoveEnemyFromCollection(BaseEnemyAI enemy)
        {
            _enemies.Remove(enemy);
            CheckPlayerState();
        }

        private void AddEnemyToCollection(BaseEnemyAI enemy)
        {
            _enemies.Add(enemy);
            CheckPlayerState();
        }

        private void CheckPlayerState()
        {
            _playerWorldStatePublisher.Value = _enemies.Any() ? PlayerWorldState.Fight : PlayerWorldState.Default;
        }

        public void Dispose()
        {
            _enemyTriggerInvoker.OnTriggerEnterEvent -= AddEnemyToCollection;
            _enemyTriggerInvoker.OnTriggerExitEvent -= RemoveEnemyFromCollection;
            _subscription.Dispose();
        }
    }

    public enum PlayerWorldState
    {
        Default,
        Fight
    }
}