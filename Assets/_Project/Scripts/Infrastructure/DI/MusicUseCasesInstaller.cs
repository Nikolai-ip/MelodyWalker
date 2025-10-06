using _Game.Scripts.Core.DI;
using _Game.Scripts.Services.Audio.Music.Data;
using _Project.Scripts.Application.UseCases.Audio;
using _Project.Scripts.Application.UseCases.Player;
using _Project.Scripts.Tools;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.DI
{
    public class MusicUseCasesInstaller: SubInstaller
    {
        [SerializeField] private DictionaryInspector<PlayerWorldState, MusicPack> _musicPacks;
        public override void InstallBindings(DiContainer Container)
        {
            Container.BindInterfacesTo<SceneMusicPackOnStartRunner>().AsCached();
            Container.BindInterfacesTo<PlayerStateMusicChanger>().AsCached().WithArguments(_musicPacks.GetDictionary());
        }
    }
}