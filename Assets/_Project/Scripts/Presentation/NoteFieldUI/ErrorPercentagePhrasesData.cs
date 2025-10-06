using System;
using System.Collections.Generic;
using _Project.Scripts.Tools;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.Presentation.NoteFieldUI
{
	[Serializable]
    public class ErrorPercentagePhrasesData
    {
        [SerializeField] private List<PhraseErrorPercentageData> _successStatusPhrasesInspector;
        [SerializeField] private string _notValidMelodyText;

        public string NotValidMelodyText => _notValidMelodyText;

        public List<PhraseErrorPercentageData> SuccessStatusPhrasesInspector => _successStatusPhrasesInspector;
    }

    [Serializable]
    public class PhraseErrorPercentageData
    {
        [field: SerializeField] public float ErrorMinPercentage { get; private set; }
        [field: SerializeField] public float ErrorMaxPercentage { get; private set; }

        [field: SerializeField] public string Phrase { get; private set; }
    }
}