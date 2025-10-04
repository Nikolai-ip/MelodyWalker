using System.Collections.Generic;
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

        public bool TryDefineMelodyByTacts(List<Tact> tacts, out Melody findedMelody)
        {
            //todo
            findedMelody = default;
            return false;
        }
    }
}