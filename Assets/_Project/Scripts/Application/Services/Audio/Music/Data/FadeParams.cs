using System;
using UnityEngine;

namespace _Game.Scripts.Services.Audio.Music.Data
{
    [Serializable]
    public class FadeParams
    {
        [field: SerializeField] public float FadeInDuration { get; private set; }
        [field: SerializeField] public float FadeOutDuration { get; private set; }
    }
}