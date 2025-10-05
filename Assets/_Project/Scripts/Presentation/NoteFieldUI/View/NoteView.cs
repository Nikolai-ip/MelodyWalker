using Plugins.DOTweenFramework;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Presentation.NoteFieldUI.View
{
    public class NoteView: MonoBehaviour, IViewEnableable<NoteViewData>
    {
        [SerializeField] private TextMeshProUGUI _noteSymbol;
        [SerializeField] private TweenAnimation _animation;
        public void SetData(NoteViewData data)
        {
            _noteSymbol.text = data.NoteSymbol;
        }

        public void Show()
        {
            _animation.Play();
        }

        public void Hide()
        {
            _animation.PlayBackwards();
        }
    }

    public struct NoteViewData
    {
        public string NoteSymbol { get; }

        public NoteViewData(string noteSymbol)
        {
            NoteSymbol = noteSymbol;
        }
    }
}