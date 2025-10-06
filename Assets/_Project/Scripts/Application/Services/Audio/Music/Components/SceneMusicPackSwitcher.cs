using System;
using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Services.Audio.Music.Abstract;
using _Game.Scripts.Services.Audio.Music.Data;
using _Game.Scripts.Services.Audio.Music.MusicSequenceStrategies;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Game.Scripts.Services.Audio.Music.Components
{
    public class SceneMusicPackSwitcher
    {
        private readonly IMusicPackPlayer _musicPackPlayer;
        private readonly IMusicStopper _musicStopper;
        private readonly MusicSequenceStrategiesFactory _sequenceStrategiesFactory = new();
        private readonly Dictionary<string, MusicPack> _scenesMusic;
        
        public SceneMusicPackSwitcher(IMusicPackPlayer musicPackPlayer, ScenesMusicData scenesMusicData, IMusicStopper musicStopper)
        {
            _musicPackPlayer = musicPackPlayer;
            _musicStopper = musicStopper;
            _scenesMusic = scenesMusicData.ScenesMusic;
        }
        
        public void PlaySceneMusicPack(string sceneName)
        {
            if (_scenesMusic.TryGetValue(sceneName, out MusicPack musicPack))
            {
                _musicPackPlayer
                    .SetMusicPack(musicPack)
                    .OrderMusic(_sequenceStrategiesFactory.GetMusicSequenceStrategy(musicPack.SequenceType))
                    .PlayCurrentMusicPack();
            }
            else
                Debug.LogError($"Failed to switch music pack for scene: {sceneName}. Set Scenes music data");
        }
        
        public void StopMusic()
        {
            _musicStopper.StopMusicSmoothlyAsync();
        }
        
    }
}