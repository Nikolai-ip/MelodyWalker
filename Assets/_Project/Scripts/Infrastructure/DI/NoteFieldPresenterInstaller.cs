using _Game.Scripts.Core.DI;
using _Project.Scripts.Presentation.NoteFieldUI;
using _Project.Scripts.Presentation.NoteFieldUI.View;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.DI
{
    public class NoteFieldPresenterInstaller: SubInstaller
    {
        [SerializeField] private NoteFieldView _noteFieldView;
        [SerializeField] private ErrorPercentageView _errorPercentageView;
        public override void InstallBindings(DiContainer Container)
        {
            Container.BindInterfacesTo<NoteFieldPresenter>().AsCached().WithArguments(_noteFieldView, _errorPercentageView).NonLazy();
        }
    }
}