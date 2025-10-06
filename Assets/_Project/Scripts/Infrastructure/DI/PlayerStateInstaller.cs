using _Project.Scripts.Application.UseCases.Enemy.AI;
using _Project.Scripts.Application.UseCases.Player;
using _Project.Scripts.Application.Utilities;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.DI
{
    public class PlayerStateInstaller: MonoInstaller
    {
        [SerializeField] private TriggerEvent _triggerEvent;
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<TriggerEvent<BaseEnemyAI>>()
                .AsSingle()
                .WithArguments(_triggerEvent);
            Container
                .BindInterfacesTo<PlayerStateComponent>()
                .AsSingle();
        }
    }
}