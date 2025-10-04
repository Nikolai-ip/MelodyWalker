using _Game.Scripts.Core.DI;
using _Project.Scripts.Application.UseCases;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Rules;
using _Project.Scripts.Domain.Services;
using _Project.Scripts.Infrastructure.Configs;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.DI
{
    public class MelodyCoreMechanicInstaller: SubInstaller
    {
        [SerializeField] private CalcMelodyErrorRule_SO _calcMelodyErrorRule;
        public override void InstallBindings(DiContainer Container)
        {
            Container
                .Bind<CalcMelodyErrorsRule>()
                .FromInstance(_calcMelodyErrorRule.GetInstance())
                .AsSingle();
            
            Container
                .Bind<MelodyPercentageErrorCalculator>()
                .AsSingle();
            
            Container
                .Bind<NotesBuffer>()
                .AsTransient();

            Container.Bind<CurrentMelodyContext>().AsSingle();

            Container
                .BindInterfacesTo<MelodyWriter>()
                .AsCached();
        }
    }
}