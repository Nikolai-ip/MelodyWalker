using System;
using UnityEngine;

namespace _Game.Scripts.Services.Audio
{
    [CreateAssetMenu(fileName = "AudioCueEventChanel", menuName = "Audio System/AudioCueEventChanel")]
    public class AudioCueEventChanel_SO: ScriptableObject
    {
        public event Action<AudioEventArgs> OnAudioEvent;

        public void RaiseEvent(AudioEventArgs e)
        {
            OnAudioEvent?.Invoke(e);
        }
    }
    
    public class AudioEventArgs: EventArgs
    {
        public AudioClip AudioClip { get; }

        public AudioEventArgs(AudioClip audioClip)
        {
            AudioClip = audioClip;
        }
    }
}