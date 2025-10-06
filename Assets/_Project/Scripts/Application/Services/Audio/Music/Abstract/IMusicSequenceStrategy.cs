using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Services.Audio.Music.Abstract
{
    public interface IMusicSequenceStrategy
    {
        List<AudioClip> GetPlaybackSequence(List<AudioClip> audioClips);
    }
}