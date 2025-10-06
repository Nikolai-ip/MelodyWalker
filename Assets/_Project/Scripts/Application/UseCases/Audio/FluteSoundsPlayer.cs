

using System;
using System.Collections.Generic;
using _Game.Scripts.Services.Audio;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Services;
using _Project.Scripts.Domain.ValueObjects;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Application.UseCases.Audio
{
    public class FluteSoundsPlayer: IInitializable, IDisposable
    {
        private readonly AudioCueEventChanel_SO _soundChanel;
        private readonly NotesBuffer _notesBuffer;
        private readonly Dictionary<int, AudioClip> _noteAudioClips;

        public FluteSoundsPlayer(AudioCueEventChanel_SO soundChanel, Dictionary<int, AudioClip> noteAudioClips, NotesBuffer notesBuffer)
        {
            _soundChanel = soundChanel;
            _noteAudioClips = noteAudioClips;
            _notesBuffer = notesBuffer;
        }

        public void Initialize()
        {
            _notesBuffer.OnNoteAdded += PlaySound;
        }

        private void PlaySound(Note note)
        {
            _soundChanel.RaiseEvent(new AudioEventArgs(_noteAudioClips[note.NoteIndex]));
        }

        public void Dispose()
        {
            _notesBuffer.OnNoteAdded -= PlaySound;
        }
    }
}