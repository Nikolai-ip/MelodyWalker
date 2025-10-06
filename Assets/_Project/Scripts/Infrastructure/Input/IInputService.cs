using System;
using _Project.Scripts.Domain.ValueObjects;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Input
{
    public interface IInputService
    {
        event Action CastApplied;
        event Action CastCancelled; 
        event Action<NoteIndex> NotePressed;
        event Action OpenAvailableMelodies;
        Vector2 MouseScreenPosition { get; }
        void TogglePlayerInput(bool isLocked);
    }
}