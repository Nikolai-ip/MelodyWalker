using System;
using System.Collections.Generic;
using _Game.Scripts.Core.DI;
using _Project.Scripts.Application.UseCases.Common;
using _Project.Scripts.Application.UseCases.SpellCasters;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Repositories;
using _Project.Scripts.Domain.Services;
using _Project.Scripts.Infrastructure.Configs;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.DI
{
    public class SpellSystemInstaller: MonoInstaller
    {
        [SerializeField] private Melody_SO _damageFullMelody;
        [SerializeField] private Melody_SO _healingFullMelody;
        [SerializeField] private Melody_SO _protectFullMelody;
        
        [SerializeField] private AreaCaster _areaCaster;
        [SerializeField] private SelfCaster _selfCaster;

        private SpellCheating _spellCheating;
        
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
                .WithArguments(new Dictionary<MelodyType, Melody>()
                {
                    { MelodyType.Damage , _damageFullMelody.GetMelody()},
                    { MelodyType.Heal , _healingFullMelody.GetMelody()},
                    { MelodyType.Protect , _protectFullMelody.GetMelody()},
                });

            Container
                .BindInterfacesAndSelfTo<SpellCheating>()
                .AsSingle();
        }
        
    }
}