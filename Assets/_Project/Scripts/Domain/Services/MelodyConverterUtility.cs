using System.Collections.Generic;
using _Project.Scripts.Domain.Entities;

namespace _Project.Scripts.Domain.Services
{
    public class MelodyConverterUtility
    {
        public static List<Note> ConvertTactsToNoteList(List<Tact> targetTacts)
        {
            var targetNoteSequence = new List<Note>();
            foreach (var tact in targetTacts)
            {
                foreach (var noteInterval in tact.ReferenceNoteIntervals)
                    targetNoteSequence.Add(noteInterval.Item2);
            }
            return targetNoteSequence;
        }
    }
}