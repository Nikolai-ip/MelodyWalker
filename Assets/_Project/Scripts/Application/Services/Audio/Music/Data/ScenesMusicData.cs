using System;
using System.Collections.Generic;
using _Project.Scripts.Tools;
using UnityEngine;

namespace _Game.Scripts.Services.Audio.Music.Data
{
    [Serializable]
    public class ScenesMusicData
    {
        [field: SerializeField] public DictionaryInspector<string, MusicPack> _scenesMusic;
        public Dictionary<string, MusicPack> ScenesMusic => _scenesMusic.GetDictionary();
    }
    
}