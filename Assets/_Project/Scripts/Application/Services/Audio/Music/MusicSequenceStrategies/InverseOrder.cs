using System.Collections.Generic;
using _Game.Scripts.Services.Audio.Music.Abstract;
using UnityEngine;

namespace _Game.Scripts.Services.Audio.Music.MusicSequenceStrategies
{
    public class InverseOrder: IMusicSequenceStrategy
    {
        public List<AudioClip> GetPlaybackSequence(List<AudioClip> audioClips)
        {
            audioClips.Reverse();
            return audioClips;
        }
    }
}