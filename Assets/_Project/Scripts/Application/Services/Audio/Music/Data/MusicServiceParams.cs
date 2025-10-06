using System;
using UnityEngine;

namespace _Game.Scripts.Services.Audio.Music.Data
{
    [Serializable]
    public class MusicServiceParams
    {
        [field: SerializeField] public float Volume { get; private set; }
        [field: SerializeField] public float Interval { get; private set; }
        [field: SerializeField] public FadeParams FadeParams { get; private set; }
    }
}