using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Presentation.NoteFieldUI
{
    [Serializable]
    public class NoteSymbolsData
    {
        [field: SerializeField] public List<string> NoteSymbols { get; private set; }
    }
}