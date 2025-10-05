using System.Collections.Generic;
using _Game.Scripts.Core.DI;
using _Project.Scripts.Application.UseCases.SpellCasters;
using _Project.Scripts.Domain.Repositories;
using _Project.Scripts.Domain.Services;
using _Project.Scripts.Infrastructure.Configs;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.DI
{
    public class SpellSystemInstaller: MonoInstaller
    {
        [SerializeField] private Melody_SO _damageMelody;
        [SerializeField] private Melody_SO _healingMelody;
        [SerializeField] private AreaCaster _areaCaster;
        [SerializeField] private SelfCaster _selfCaster;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SpellRunner>().AsSingle();

            Container
                .Bind<CastersRepository>()
                .AsSingle()
                .WithArguments(new List<Caster>() { _areaCaster, _selfCaster });
                
            Container
                .Bind<SpellDataRepository>()
                .AsSingle()
                .WithArguments(_damageMelody.GetMelody(), _healingMelody.GetMelody());
        }
        
    }
}