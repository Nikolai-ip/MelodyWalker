using System.Collections.Generic;
using _Game.Scripts.Services.Audio.Music.Abstract;
using UnityEngine;

namespace _Game.Scripts.Services.Audio.Music.MusicSequenceStrategies
{
    public class ForwardOrder: IMusicSequenceStrategy
    {
        public List<AudioClip> GetPlaybackSequence(List<AudioClip> audioClips)
        {
            return audioClips;
        }
    }
}