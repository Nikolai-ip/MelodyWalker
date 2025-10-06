using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using _Game.Scripts.Services.Audio.Music.Abstract;
using _Game.Scripts.Services.Audio.Music.Data;
using _Game.Scripts.Services.Audio.Utilities;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Game.Scripts.Services.Audio.Music
{
    public class MusicService : IMusicService
    {
        private readonly AudioSource _audioSource;
        private readonly FadeParams _fadeParams;
        private readonly AudioFader _audioFader = new();
        private readonly float _interval;
        private readonly float _globalVolume;
        private bool _enabled = true;
        private CancellationTokenSource _cts;
        private readonly MusicServiceContext _context = new();

        public MusicService(AudioSource audioSource, MusicServiceParams @params)
        {
            _audioSource = audioSource;
            _interval = @params.Interval;
            _globalVolume = @params.Volume;
            _audioSource.volume = _globalVolume;
            _fadeParams = @params.FadeParams;
        }

        public MusicService SetMusicPack(MusicPack musicPack)
        {
            Debug.Log("[MusicService] SetMusicPack");
            _context.MusicPack = musicPack.Clips;
            return this;
        }

        public MusicService OrderMusic(IMusicSequenceStrategy sequenceStrategy)
        {
            CheckMusicPack();
            _context.SequenceStrategy = sequenceStrategy;
            _context.MusicPack = _context.SequenceStrategy.GetPlaybackSequence(_context.MusicPack);
            return this;
        }

        public void PlayCurrentMusicPack()
        {
            if (!_enabled) return;
            CheckMusicPack();

            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            PlayMusicPackAsync(_cts.Token).Forget();
        }

        private async UniTaskVoid PlayMusicPackAsync(CancellationToken token)
        {
            int index = 0;

            while (!token.IsCancellationRequested)
            {
                var audioClip = _context.MusicPack[index];
                await PlayAudioAsync(audioClip, token);

                index++;
                if (index >= _context.MusicPack.Count)
                    index = 0;

                await UniTask.Delay(TimeSpan.FromSeconds(_interval), cancellationToken: token);
            }
        }

        private async UniTask PlayAudioAsync(AudioClip audioClip, CancellationToken token)
        {
            float timeToFadeOut = Mathf.Max(0f, audioClip.length - _fadeParams.FadeOutDuration);

            _audioSource.clip = audioClip;
            _audioSource.Play();
            await _audioFader.FadeAsync(_audioSource, true, _fadeParams.FadeInDuration, _globalVolume, token);
            await UniTask.Delay(TimeSpan.FromSeconds(timeToFadeOut), cancellationToken: token);
            await _audioFader.FadeAsync(_audioSource, false, _fadeParams.FadeOutDuration, _globalVolume, token);
            _audioSource.Stop();
        }

        private void CheckMusicPack()
        {
            if (_context.IsEmpty)
                throw new NullReferenceException("MusicPack is empty. Use SetMusicPack first.");
        }

        public async UniTask StopMusicSmoothlyAsync()
        {
            _cts?.Cancel();
            await _audioFader.FadeAsync(_audioSource, false, _fadeParams.FadeOutDuration, _globalVolume);
            _audioSource.Stop();
        }
        

        public void StopMusic()
        {
            _cts?.Cancel();
            _audioSource.Stop();
        }

        public void PlayTrackOnce(AudioClip track)
        {
            // TODO: аналогично PlayAudioAsync, но без цикла
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _cts?.Cancel();
            _cts?.Dispose();
        }
    }

    internal class MusicServiceContext
    {
        public List<AudioClip> MusicPack { get; set; }
        public IMusicSequenceStrategy SequenceStrategy { get; set; }
        public bool IsEmpty => MusicPack == null || MusicPack == null;
    }
}