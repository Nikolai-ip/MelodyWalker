using System.Collections.Generic;
using _Project.Scripts.Domain.Entities;

namespace _Project.Scripts.Application.DTOs
{
    public class NewMelodyLearned
    {
        public List<Note> NewMelodyNotes { get; }

        public NewMelodyLearned(List<Note> newMelodyNotes)
        {
            NewMelodyNotes = newMelodyNotes;
        }
    }
}