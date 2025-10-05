using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Domain.Entities;

namespace _Project.Scripts.Domain.Services
{
    public class TactsCounter
    {
        public int DetectPerformedTacts(List<Note> notes, Melody targetMelody)
        {
            if (notes == null || notes.Count == 0)
                return 0;

            if (targetMelody == null || targetMelody.Tacts == null || targetMelody.Tacts.Count == 0)
                return 0;

            int performedTacts = 0;
            int currentNoteIndex = 0;

            foreach (var tact in targetMelody.Tacts)
            {
                var tactNotes = tact.ReferenceNoteIntervals.Select(n => n.Item2.NoteIndex).ToList();

                if (currentNoteIndex + tactNotes.Count > notes.Count)
                    break;

                bool tactMatches = true;

                for (int i = 0; i < tactNotes.Count; i++)
                {
                    if (notes[currentNoteIndex + i].NoteIndex != tactNotes[i])
                    {
                        tactMatches = false;
                        break;
                    }
                }

                if (tactMatches)
                {
                    performedTacts++;
                    currentNoteIndex += tactNotes.Count;
                }
                else
                {
                    break;
                }
            }

            return performedTacts;
        }
    }
}