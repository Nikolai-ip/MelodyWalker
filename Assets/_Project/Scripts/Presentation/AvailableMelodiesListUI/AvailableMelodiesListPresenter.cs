using System;
using System.Collections.Generic;
using _Project.Scripts.Application.DTOs;
using _Project.Scripts.Domain.Repositories;
using _Project.Scripts.Domain.Services;
using _Project.Scripts.Infrastructure.Input;
using _Project.Scripts.Presentation.NoteFieldUI.View;
using MessagePipe;
using Zenject;

namespace _Project.Scripts.Presentation.AvailableMelodiesListUI
{
    public class AvailableMelodiesListPresenter: IInitializable, IDisposable
    {
        private readonly IInputService _inputService;
        private readonly PlayerMelodyRepository _playerMelodyRepository;
        private readonly List<NoteFieldView> _noteFieldViews;
        private readonly IViewEnableable _popUpWindow;
        private readonly IDisposable _newMelodyLearnedSub;
        private bool _isOpen;

        public AvailableMelodiesListPresenter(IViewEnableable popUpWindow, List<NoteFieldView> noteFieldViews, IInputService inputService, PlayerMelodyRepository playerMelodyRepository, ISubscriber<NewMelodyLearned> newMelodyLearned)
        {
            _inputService = inputService;
            _playerMelodyRepository = playerMelodyRepository;
            _newMelodyLearnedSub = newMelodyLearned.Subscribe(OnNewMelodyLearned);
            _noteFieldViews = noteFieldViews;
            _popUpWindow = popUpWindow;
        }

        
        public void Initialize()
        {
            _inputService.OpenAvailableMelodies += OnOpenButtonPressed;
            CloseWindow();
        }

        private void OnOpenButtonPressed()
        {
            if (_isOpen)
                CloseWindow();
            else
                OpenAvailableMelodiesWindow();
        }

        private void CloseWindow()
        {
            _isOpen = false;
            _popUpWindow.Hide();
            foreach (var noteFieldView in _noteFieldViews)
            {
                noteFieldView.SetData(new NoteFieldViewData().OnClearField());
            }
        }
        private void OnNewMelodyLearned(NewMelodyLearned newMelodyLearnedSignal)
        {
            if (_isOpen)
            {
                UpdateNoteFieldView();
            }   
        }
        private void OpenAvailableMelodiesWindow()
        {
            _isOpen = true;
            _popUpWindow.Show();
            UpdateNoteFieldView();
        }

        private void UpdateNoteFieldView()
        {
            for (int i = 0; i < _playerMelodyRepository.Melodies.Count; i++)
            {
                var noteList = MelodyConverterUtility.ConvertTactsToNoteList(_playerMelodyRepository.Melodies[i].Tacts);
                for (var j = 0; j < noteList.Count; j++)
                    _noteFieldViews[i].SetData(new NoteFieldViewData().OnAddNode(j,noteList[j].NoteIndex - 1));
            }
        }

        public void Dispose()
        {
            _inputService.OpenAvailableMelodies -= OnOpenButtonPressed;
            _newMelodyLearnedSub.Dispose();
        }
    }
}