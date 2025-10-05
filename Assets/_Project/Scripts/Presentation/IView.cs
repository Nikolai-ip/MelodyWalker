using System;

namespace _Project.Scripts.Presentation
{
    public interface IView<in TViewData>
    {
        void SetData(TViewData data);
    }

    public interface IViewEnableable<in TViewData> : IView<TViewData>
    {
        void Show();
        void Hide();
    }

    public interface IViewInteractable<out TViewCallback>
    {
        event Action<TViewCallback> Callback;
    }
}