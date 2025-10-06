using System;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Services.Audio
{
    public class SoundsService: IInitializable, IDisposable
    {
        private readonly AudioSource[] _buffer;
        private readonly AudioCueEventChanel_SO _audioCue;
        private bool _enabled;

        public SoundsService(AudioSource[] buffer, AudioCueEventChanel_SO audioCue)
        {
            _buffer = buffer;
            _audioCue = audioCue;
        }
        
        private void SwitchSound(AudioEventArgs eventArgs)
        {
            if (!_enabled) return;
            var audioSource = GetFreeAudioSource();
            audioSource.Stop();
            audioSource.clip = eventArgs.AudioClip;
            audioSource.Play();
        }

        private AudioSource GetFreeAudioSource()
        {
            foreach (var audioSource in _buffer)
            {
                if (!audioSource.isPlaying)
                    return audioSource;
            }
            return _buffer[0];
        }
        public void Initialize()
        {
            _audioCue.OnAudioEvent += SwitchSound;
        }

        public void Dispose()
        {
            _audioCue.OnAudioEvent -= SwitchSound;
        }
    }
    
}