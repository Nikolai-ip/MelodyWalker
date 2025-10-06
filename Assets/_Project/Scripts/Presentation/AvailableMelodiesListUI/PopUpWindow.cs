using Plugins.DOTweenFramework;
using UnityEngine;

namespace _Project.Scripts.Presentation.AvailableMelodiesListUI
{
    public class PopUpWindow: MonoBehaviour, IViewEnableable
    {
        [SerializeField] private TweenAnimation _openAnimation;
        [SerializeField] private GameObject _windowObject;
        
        public void Show()
        {
            _windowObject.SetActive(true);
            _openAnimation.Play();
        }

        public void Hide()
        {
            _windowObject.SetActive(false);
        }
    }
}