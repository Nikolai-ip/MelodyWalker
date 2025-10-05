using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Services;
using Zenject;

namespace _Project.Scripts.Test
{
    public class TestMelodyDefiner: IInitializable
    {
        private MelodyDefiner _definer;

        public TestMelodyDefiner(MelodyDefiner definer)
        {
            _definer = definer;
        }

        public void Initialize()
        {
            _definer.TryDefineMelodyByTacts(GetMelody4().Select(im=>im.Item2).ToList(), out var melody);
        }
        public List<Tuple<float, Note>> GetMelody4()
        {
            return new List<Tuple<float, Note>>()
            {
                new(0.4f, new Note(3)),
                new(0.4f, new Note(5)),
                new(0.4f, new Note(8)),
                new(0.4f, new Note(5)),
            };
        }
    }
}