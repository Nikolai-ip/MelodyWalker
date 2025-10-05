using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Repositories;
using _Project.Scripts.Domain.Rules;

namespace _Project.Scripts.Domain.Services
{
    public class MelodyDefiner
    {
        private MelodyRepository _melodyRepository;

        public MelodyDefiner(MelodyRepository melodyRepository)
        {
            _melodyRepository = melodyRepository;
        }

        // public bool TryDefineMelodyByTacts(List<Tuple<float, Note>> notes, out Melody foundMelody)
        // {
        //     foreach (var note in notes)
        //     {
        //      
        //     }
        //     return false;
        // }
    }
}