using System.Collections.Generic;
using _Game.Scripts.Core.DI;
using _Project.Scripts.Presentation.AvailableMelodiesListUI;
using _Project.Scripts.Presentation.NoteFieldUI.View;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.DI
{
    public class AvailableMelodiesListUIInstaller: SubInstaller
    {
        [SerializeField] private PopUpWindow _popUpWindow;
        [SerializeField] private List<NoteFieldView> _noteFieldViews;
        public override void InstallBindings(DiContainer Container)
        {
            Container.BindInterfacesTo<AvailableMelodiesListPresenter>().AsCached()
                .WithArguments(_popUpWindow, _noteFieldViews);
        }
    }
}