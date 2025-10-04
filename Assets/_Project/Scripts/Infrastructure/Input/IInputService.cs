using System;
using _Project.Scripts.Domain.ValueObjects;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Input
{
    public interface IInputService
    {
        event Action CastApplied;
        event Action<Note> NotePressed;
        Vector3 MoveToPos { get; }
    }
}