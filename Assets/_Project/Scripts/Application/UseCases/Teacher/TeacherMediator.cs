using System;
using _Project.Scripts.Application.UseCases.Player;
using _Project.Scripts.Application.Utilities;
using _Project.Scripts.Domain.Entities;
using Zenject;

namespace _Project.Scripts.Application.UseCases.Teacher
{
    public class TeacherMediator: IInitializable, IDisposable
    {
        private readonly ITriggerEventInvoker<PlayerEntityContainer> _triggerEventInvoker;
        private readonly Melody _melody;

        public TeacherMediator(ITriggerEventInvoker<PlayerEntityContainer> triggerEventInvoker, Melody melody)
        {
            _triggerEventInvoker = triggerEventInvoker;
            _melody = melody;
        }

        public void Initialize()
        {
            _triggerEventInvoker.OnTriggerEnterEvent += OnPlayerEnter;
            _triggerEventInvoker.OnTriggerExitEvent += OnPlayerExit;
        }

        private void OnPlayerExit(PlayerEntityContainer player)
        {
        }

        private void OnPlayerEnter(PlayerEntityContainer player)
        {
            player.MelodyReplacer.ReplaceOrAddMelody(_melody);
            _triggerEventInvoker.Enable = false;
        }

        public void Dispose()
        {
            _triggerEventInvoker.OnTriggerEnterEvent -= OnPlayerEnter;
            _triggerEventInvoker.OnTriggerExitEvent -= OnPlayerExit;
        }
    }
}