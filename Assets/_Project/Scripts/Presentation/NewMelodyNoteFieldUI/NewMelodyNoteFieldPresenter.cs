using System;
using System.Threading;
using _Project.Scripts.Application.DTOs;
using _Project.Scripts.Presentation.NoteFieldUI.View;
using Cysharp.Threading.Tasks;
using MessagePipe;
using Zenject;

namespace _Project.Scripts.Presentation.NewMelodyNoteFieldUI
{
    public class NewMelodyNoteFieldPresenter: IInitializable, IDisposable
    {
        private readonly IDisposable _subscription;
        private readonly IViewEnableable<NoteFieldViewData> _noteFieldView;
        private readonly float _timeToHideNoteField;
        private CancellationTokenSource _timerCts;
        
        public NewMelodyNoteFieldPresenter(IViewEnableable<NoteFieldViewData> noteFieldView,
            ISubscriber<NewMelodyLearned> onNewMelodyPublisher, float timeToHideNoteField)
        {
            _noteFieldView = noteFieldView;
            _timeToHideNoteField = timeToHideNoteField;
            _subscription = onNewMelodyPublisher.Subscribe(ShowNoteFiledUI);
        }
        public void Initialize()
        {
            _noteFieldView.Hide();
        }
        private void ShowNoteFiledUI(NewMelodyLearned  newMelody)
        {
            _noteFieldView.Show();
            for (int i = 0; i < newMelody.NewMelodyNotes.Count; i++)
            {
                _noteFieldView.SetData(new NoteFieldViewData().OnAddNode(i, newMelody.NewMelodyNotes[i].NoteIndex - 1));
            }
            _timerCts?.Cancel();
            _timerCts = new();
            TimerToHideNoteField();
        }

        private async void TimerToHideNoteField()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_timeToHideNoteField), DelayType.DeltaTime, PlayerLoopTiming.Update, _timerCts.Token);
            _noteFieldView.Hide();
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }


    }
}