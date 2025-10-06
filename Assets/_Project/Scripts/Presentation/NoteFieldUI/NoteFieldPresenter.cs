using System;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Services;
using _Project.Scripts.Presentation.NoteFieldUI.View;
using Zenject;

namespace _Project.Scripts.Presentation.NoteFieldUI
{
    public class NoteFieldPresenter: IInitializable, IDisposable
    {
        private readonly CurrentMelodyContext _melodyContext;
        private readonly NotesBuffer _notesBuffer;
        private readonly IView<NoteFieldViewData> _noteFieldView;
        private readonly IViewEnableable<ErrorPercentageViewData> _errorPercentageView;

        public NoteFieldPresenter(IView<NoteFieldViewData> noteFieldView, IViewEnableable<ErrorPercentageViewData> errorPercentageView, CurrentMelodyContext melodyContext, NotesBuffer notesBuffer)
        {
            _melodyContext = melodyContext;
            _noteFieldView = noteFieldView;
            _notesBuffer = notesBuffer;
            _errorPercentageView = errorPercentageView;
        }

        public void Initialize()
        {
            _notesBuffer.OnNoteAdded += UpdateNoteField;
            _melodyContext.OnContextCleared += HideNotes;
        }

        private void HideNotes()
        {
            _noteFieldView.SetData(new NoteFieldViewData().OnClearField());
        }

        private void UpdateNoteField(Note note)
        {
            _noteFieldView.SetData(new NoteFieldViewData().OnAddNode(_melodyContext.CurrentNotes.Count, note.NoteIndex - 1));
            _errorPercentageView.Show();
            _errorPercentageView.SetData(new ErrorPercentageViewData(_melodyContext.ErrorPercentage.Value));
        }
        

        public void Dispose()
        {
            _notesBuffer.OnNoteAdded -= UpdateNoteField;
            _melodyContext.OnContextCleared -= HideNotes;
        }
    }
}