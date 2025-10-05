using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Rules;

namespace _Project.Scripts.Domain.Services
{
    public class MelodyPercentageErrorCalculator
    {
        private readonly CalcMelodyErrorsRule _calcMelodyErrorsRule;

        public MelodyPercentageErrorCalculator(CalcMelodyErrorsRule calcMelodyErrorsRule)
        {
            _calcMelodyErrorsRule = calcMelodyErrorsRule;
        }
        
        public float CalcTactsErrorPercentage(List<Tact> targetTacts, List<Tuple<float, Note>> notes)
        {
            float errorPercentage = 0f;
            float errorAccum = 0f;
            List<Note> targetNoteSequence = GetTargetNoteSequence(targetTacts);
            
            for (var i = 0; i < notes.Count; i++)
            {
                if (!TryFindNoteInTacts(targetTacts, i, out var noteInTargetTacts))
                    throw new ArgumentException($"Failed to find note in target tacts with id {i}");
                
                bool isNoteCorrect = targetNoteSequence[i].NoteIndex == noteInTargetTacts.Item2.NoteIndex;
                float referenceNoteInterval = noteInTargetTacts.Item1;
                float intervalErrorPercentage = Math.Clamp(Math.Abs(referenceNoteInterval - notes[i].Item1), 0f, 1f);

                float noteErrorPercentage = GetNoteErrorPercentage(isNoteCorrect, intervalErrorPercentage);
               
                errorAccum += noteErrorPercentage;
            }
            errorPercentage = errorAccum / notes.Count;

            return errorPercentage;
        }

        private float GetNoteErrorPercentage(bool isNoteCorrect, float intervalErrorPercentage)
        {
            float intervalErrorValue = intervalErrorPercentage * _calcMelodyErrorsRule.MaxWrongIntervalWeight;
            float result = 0;
            result += intervalErrorValue;
            result += isNoteCorrect ? 0 : _calcMelodyErrorsRule.WrongNoteErrorWeight;
            result = Math.Clamp(result, 0f, 1f);
            return result;
        }
        private bool TryFindNoteInTacts(List<Tact> tacts, int noteIndex, out Tuple<float, Note> note)
        {
            note = null;
            foreach (var tact in tacts)
            {
                foreach (var n in tact.ReferenceNoteIntervals)
                {
                    if (noteIndex == 0)
                    {
                        note = n;
                        return true;
                    }
                    noteIndex--;
                }
            }
            return false;
        }

        private List<Note> GetTargetNoteSequence(List<Tact> targetTacts)
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