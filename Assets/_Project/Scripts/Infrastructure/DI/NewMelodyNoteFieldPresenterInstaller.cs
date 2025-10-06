using _Game.Scripts.Core.DI;
using _Project.Scripts.Presentation.NewMelodyNoteFieldUI;
using _Project.Scripts.Presentation.NoteFieldUI.View;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.DI
{
    public class NewMelodyNoteFieldPresenterInstaller: SubInstaller
    {
        [SerializeField] private NoteFieldView _newMelodyNoteFieldView;
        [SerializeField] private float _timeToHideNoteField;
        public override void InstallBindings(DiContainer Container)
        {
            Container.BindInterfacesTo<NewMelodyNoteFieldPresenter>().AsCached().WithArguments(_newMelodyNoteFieldView, _timeToHideNoteField);
        }
    }
}