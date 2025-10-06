using _Game.Scripts.Core.DI;
using _Project.Scripts.Application.UseCases;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Repositories;
using _Project.Scripts.Domain.Rules;
using _Project.Scripts.Domain.Services;
using _Project.Scripts.Infrastructure.Configs;
using _Project.Scripts.Test;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.DI
{
    public class MelodySystemInstaller: SubInstaller
    {
        [SerializeField] private CalcMelodyErrorRule_SO _calcMelodyErrorRule;
        [SerializeField] private MelodyRepository_SO _melodyRepository;
        public override void InstallBindings(DiContainer Container)
        {
            Container
                .Bind<MelodyRepository>()
                .AsSingle()
                .WithArguments(_melodyRepository.GetMelodies());
            
            Container
                .Bind<CalcMelodyErrorsRule>()
                .FromInstance(_calcMelodyErrorRule.GetInstance())
                .AsSingle();
            
            Container
                .Bind<MelodyPercentageErrorCalculator>()
                .AsSingle();
            
            Container
                .Bind<NotesBuffer>()
                .AsSingle();

            Container.Bind<CurrentMelodyContext>().AsSingle();

            Container
                .BindInterfacesTo<MelodyContextWriter>()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<MelodyDefiner>()
                .AsSingle();

            Container
                .Bind<TactsCounter>()
                .AsSingle();
        }
    }
}