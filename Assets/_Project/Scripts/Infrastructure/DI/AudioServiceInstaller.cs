using _Game.Scripts.Core.DI;
using _Game.Scripts.Services.Audio;
using _Game.Scripts.Services.Audio.Music;
using _Game.Scripts.Services.Audio.Music.Components;
using _Game.Scripts.Services.Audio.Music.Data;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.DI
{
    public class AudioServiceInstaller: SubInstaller
    {
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private MusicServiceParams _musicServiceParams;
        [SerializeField] private ScenesMusicData _scenesMusicData;
        [SerializeField] private AudioCueEventChanel_SO _soundChanel;
        [SerializeField] private AudioSource[] _soundsAudioSourceBuffer;

        public override void InstallBindings(DiContainer Container)
        {
            Container
                .BindInterfacesTo<MusicService>()
                .AsSingle()
                .WithArguments(_musicSource, _musicServiceParams);

            Container
                .BindInterfacesAndSelfTo<SceneMusicPackSwitcher>()
                .AsSingle()
                .WithArguments(_scenesMusicData);
            
            Container
                .BindInterfacesAndSelfTo<SoundsService>()
                .AsCached()
                .WithArguments(_soundChanel, _soundsAudioSourceBuffer);
        }
    }
}