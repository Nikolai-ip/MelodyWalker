using System;
using System.Collections.Generic;
using _Game.Scripts.Services.Audio.Music.MusicSequenceStrategies;
using UnityEngine;

namespace _Game.Scripts.Services.Audio.Music.Data
{
    [Serializable]
    public class MusicPack
    {
        [field: SerializeField] public MusicPackSequenceType SequenceType { get; private set; }
        [field: SerializeField] public List<AudioClip> Clips { get; private set; }
    }
}