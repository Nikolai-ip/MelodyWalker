using System;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Presentation.NoteFieldUI.View
{
    public class NoteFieldView: MonoBehaviour, IViewEnableable<NoteFieldViewData>
    {
        [SerializeField] private NoteView[] _noteViews;
        [SerializeField] private NoteSymbolsData _noteSymbolsData;
        [SerializeField] private GameObject _field;
        
        public void SetData(NoteFieldViewData data)
        {
            if (data.Action == NoteFieldViewData.ActionType.AddNode)
            {
                _noteViews[data.NoteNumber].Show();
                _noteViews[data.NoteNumber].SetData(new NoteViewData(_noteSymbolsData.NoteSymbols[data.NoteType]));
            }
            else if (data.Action == NoteFieldViewData.ActionType.ClearField)
            {
                for (int i = 0; i < _noteViews.Length; i++)
                {
                    _noteViews[i].Hide();
                }   
            }

        }

        public void Show()
        {
            _field.SetActive(true);
        }

        public void Hide()
        {
            _field.SetActive(false);
        }
    }

    public struct NoteFieldViewData
    {
        public enum ActionType
        {
            AddNode,
            ClearField
        }
        public int NoteNumber { get; private set; }
        public int NoteType { get; private set; }
        public ActionType  Action { get; set; }

        public NoteFieldViewData OnAddNode(int noteNumber, int noteType)
        {
            NoteNumber = noteNumber;
            NoteType = noteType;
            Action = ActionType.AddNode;
            return this;
        }
        public NoteFieldViewData OnClearField()
        {
            Action = ActionType.ClearField;
            return this;
        }
    }
}