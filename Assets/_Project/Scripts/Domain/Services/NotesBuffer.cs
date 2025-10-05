using System;
using System.Threading;
using _Project.Scripts.Domain.Entities;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Domain.Services
{
    public class NotesBuffer
    {
        private Note _noteBuffer;
        private float _noteDuration;
        private CancellationTokenSource _timerCts;
        public bool IsEmpty => _noteBuffer == null;
        public void AddNoteIndexToBuffer(int noteIndex)
        {
            _noteBuffer = new Note(noteIndex);
            _noteDuration = 0;
            _timerCts = new();
            StartTimer();
        }

        private async void StartTimer()
        {
            try
            {
                while (!_timerCts.IsCancellationRequested)
                {
                    _noteDuration += Time.deltaTime;
                    await UniTask.Yield(PlayerLoopTiming.Update, _timerCts.Token);
                }
            }
            catch (OperationCanceledException)
            { }
        }

        public Tuple<float, Note> GetIntervalAndNoteFromBuffer()
        {
            _timerCts.Cancel();
            _timerCts = null;
            return new Tuple<float, Note>(_noteDuration, _noteBuffer);
        }
    }
}