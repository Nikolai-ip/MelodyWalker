using System;
using _Project.Scripts.Domain.ValueObjects;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.Input
{
    public class InputService : IInputService, IInitializable, ITickable
    {
        private readonly InputActionsScheme _inputScheme = new();

        public event Action CastApplied;
        public event Action CastCancelled;
        public event Action<Note> NotePressed;
        public Vector2 MouseScreenPosition { get; private set; }

        public void Initialize()
        {
            _inputScheme.Player.Note1.performed += ctx => NotePressed?.Invoke(Note.Note1);
            _inputScheme.Player.Note2.performed += ctx => NotePressed?.Invoke(Note.Note2);
            _inputScheme.Player.Note3.performed += ctx => NotePressed?.Invoke(Note.Note3);
            _inputScheme.Player.Note4.performed += ctx => NotePressed?.Invoke(Note.Note4);
            _inputScheme.Player.Note5.performed += ctx => NotePressed?.Invoke(Note.Note5);
            _inputScheme.Player.Note6.performed += ctx => NotePressed?.Invoke(Note.Note6);
            _inputScheme.Player.Note7.performed += ctx => NotePressed?.Invoke(Note.Note7);
            
            _inputScheme.Player.ApplyCast.performed += ctx => CastApplied?.Invoke();
            _inputScheme.Player.CancelCast.performed += ctx => CastCancelled?.Invoke();

            TogglePlayerInput(true);
        }

        public void Tick()
        {
            if (_inputScheme.Player.enabled)
                MouseScreenPosition = _inputScheme.Player.MouseScreenPosition.ReadValue<Vector2>();
        }

        public void TogglePlayerInput(bool enabled)
        {
            if (enabled)
            {
                _inputScheme.Player.Enable();
                return;
            }
            
            _inputScheme.Player.Disable();
        }
    }
}