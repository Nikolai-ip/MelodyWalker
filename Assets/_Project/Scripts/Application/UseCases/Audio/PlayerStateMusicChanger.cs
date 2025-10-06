using System;
using System.Collections.Generic;
using _Game.Scripts.Services.Audio.Music.Abstract;
using _Game.Scripts.Services.Audio.Music.Data;
using _Project.Scripts.Application.UseCases.Player;
using MessagePipe;
using Zenject;

namespace _Project.Scripts.Application.UseCases.Audio
{
    public class PlayerStateMusicChanger: IInitializable, IDisposable
    {
        private readonly ISubscriber<PlayerWorldState> _playerStateSubscriber;
        private IDisposable _playerStateSubscription;
        private readonly IMusicPackPlayer _musicPackPlayer;
        private readonly Dictionary<PlayerWorldState, MusicPack> _musicPacks;

        public PlayerStateMusicChanger(ISubscriber<PlayerWorldState> playerStateSubscriber, IMusicPackPlayer musicPackPlayer, Dictionary<PlayerWorldState, MusicPack> musicPacks)
        {
            _playerStateSubscriber = playerStateSubscriber;
            _musicPackPlayer = musicPackPlayer;
            _musicPacks = musicPacks;
        }

        public void Initialize()
        {
            _playerStateSubscription = _playerStateSubscriber.Subscribe(SetMelodyPack);
        }

        private void SetMelodyPack(PlayerWorldState state)
        {
            _musicPackPlayer.SetMusicPack(_musicPacks[state]);
            _musicPackPlayer.PlayCurrentMusicPack();
        }

        public void Dispose()
        {
            _playerStateSubscription.Dispose();
        }
    }
}