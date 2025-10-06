using _Game.Scripts.Services.Audio.Music.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Game.Scripts.Services.Audio.Music.Abstract
{
    public interface IMusicPackPlayer
    {
        MusicService SetMusicPack(MusicPack musicPack);
        MusicService OrderMusic(IMusicSequenceStrategy sequenceStrategy);
        void PlayCurrentMusicPack();
    }

    public interface IMusicStopper
    {
        UniTask StopMusicSmoothlyAsync();
        void StopMusic();
    }

    public interface IAudioTrackPlayer
    {
        void PlayTrackOnce(AudioClip track);
    }

    public interface IMusicService : IMusicPackPlayer, IMusicStopper, IAudioTrackPlayer
    {
    }
}