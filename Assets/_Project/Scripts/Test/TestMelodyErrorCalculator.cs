using System;
using System.Collections.Generic;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Rules;
using _Project.Scripts.Domain.Services;
using UnityEngine;

namespace _Project.Scripts.Test
{
    public class TestMelodyErrorCalculator: MonoBehaviour
    {
        private void Start()
        {
            var rules = new CalcMelodyErrorsRule(0,0, 0.5f, 0.5f);
            var calculator = new MelodyPercentageErrorCalculator(rules);
            var melody = GetMelody();
            Debug.Log("GetNotCorrectNoteSequence2 " + calculator.CalcTactsErrorPercentage(melody.Tacts, GetNotCorrectNoteSequence2()));
            Debug.Log("GetFullCorrectNoteSequence " + calculator.CalcTactsErrorPercentage(melody.Tacts, GetFullCorrectNoteSequence()));
            Debug.Log("GetSmallCorrectNoteSequence " + calculator.CalcTactsErrorPercentage(melody.Tacts, GetSmallCorrectNoteSequence()));
            Debug.Log("GetNotCorrectNoteSequence" + calculator.CalcTactsErrorPercentage(melody.Tacts, GetNotCorrectNoteSequence()));
        }

        private List<Tuple<float, Note>> GetSmallCorrectNoteSequence()
        {
            return new List<Tuple<float, Note>>()
            {
                new(0.25f, new Note(1)),
                new(0.3f, new Note(3)),
                new(0.6f, new Note(2)),
                new(0.45f, new Note(1)),
            };
        }
        private List<Tuple<float, Note>> GetNotCorrectNoteSequence()
        {
            return new List<Tuple<float, Note>>()
            {
                new(0.25f, new Note(3)),
                new(0.3f, new Note(2)),
                new(0.6f, new Note(1)),
                new(0.45f, new Note(5)),
            };
        }
        private List<Tuple<float, Note>> GetNotCorrectNoteSequence2()
        {
            return new List<Tuple<float, Note>>()
            {
                new(0.5f, new Note(3)),
                new(0.1f, new Note(2)),
                new(0.3f, new Note(1)),
                new(0.7f, new Note(5)),
            };
        }

        private List<Tuple<float, Note>> GetFullCorrectNoteSequence()
        {
            return new List<Tuple<float, Note>>()
            {
                new(0.25f, new Note(1)),
                new(0.3f, new Note(3)),
                new(0.6f, new Note(2)),
                new(0.45f, new Note(1)),
                new(0.35f, new Note(4)),
                new(0.2f, new Note(7)),
                new(0.5f, new Note(5)),
                new(0.3f, new Note(6)),
                new(0.1f, new Note(2)),
                new(0.1f, new Note(2)),
                new(0.4f, new Note(3)),
                new(0.5f, new Note(1)),
                new(0.6f, new Note(3)),
                new(0.5f, new Note(5)),
                new(0.6f, new Note(2)),
                new(0.12f, new Note(3)),
            };
        }

        private Melody GetMelody()
        {
            var tacts = new List<Tact>()
            {
                new Tact(new List<Tuple<float, Note>>
                {
                    new(0.25f, new Note(1)),
                    new(0.3f, new Note(3)),
                    new(0.6f, new Note(2)),
                    new(0.45f, new Note(1)),
                }),
                new Tact(new List<Tuple<float, Note>>
                {
                    new(0.35f, new Note(4)),
                    new(0.2f, new Note(7)),
                    new(0.5f, new Note(5)),
                    new(0.3f, new Note(6)),
                }),
                new Tact(new List<Tuple<float, Note>>
                {
                    new(0.1f, new Note(2)),
                    new(0.1f, new Note(2)),
                    new(0.4f, new Note(3)),
                    new(0.5f, new Note(1)),
                }),
                new Tact(new List<Tuple<float, Note>>
                {
                    new(0.6f, new Note(3)),
                    new(0.5f, new Note(5)),
                    new(0.6f, new Note(2)),
                    new(0.12f, new Note(3)),
                })
            };

            return new Melody(tacts);
        }
    }
}