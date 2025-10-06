using UnityEngine;
using Zenject;

namespace _Game.Scripts.Services.Audio
{
    public class AudioComponent: MonoBehaviour
    {
        private AudioCueEventChanel_SO _audioCueEventChanel_SO;
        [SerializeField] private AudioClip _audioClip;

        [Inject]
        public void Construct(AudioCueEventChanel_SO audioCueEventChanel_SO)
        {
            _audioCueEventChanel_SO = audioCueEventChanel_SO;
        }
        public void PlayAudio()
        {
            _audioCueEventChanel_SO.RaiseEvent(new AudioEventArgs(_audioClip));
        }
    }
}