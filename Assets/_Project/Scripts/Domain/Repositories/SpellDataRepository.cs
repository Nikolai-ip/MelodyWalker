using System;
using System.Collections.Generic;
using _Project.Scripts.Application.UseCases.SpellCasters;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Entities.Spells;

namespace _Project.Scripts.Domain.Repositories
{
    public class SpellDataRepository
    {
        private readonly CastersRepository _castersRepository;
        private readonly HealSpell _healSpell = new();
        private readonly DamageSpell _damageSpell = new();

        public Dictionary<Melody, List<Action<float>>> Spells { get; }

        public SpellDataRepository(Melody damageMelody, Melody healMelody, CastersRepository castersRepository)
        {
            _castersRepository = castersRepository;
            Spells = new Dictionary<Melody, List<Action<float>>>()
            {
                {
                    damageMelody,
                    new List<Action<float>>()
                    {
                        (errorPercent) => _castersRepository.GetCaster<AreaCaster>().Cast(_damageSpell, errorPercent),
                        (errorPercent) => _castersRepository.GetCaster<AreaCaster>().Cast(_damageSpell, errorPercent),
                        (errorPercent) => _castersRepository.GetCaster<AreaCaster>().Cast(_damageSpell, errorPercent),
                        (errorPercent) => _castersRepository.GetCaster<AreaCaster>().Cast(_damageSpell, errorPercent),
                    }
                },
                {
                    healMelody,
                    new List<Action<float>>()
                    {
                        (errorPercent) => _castersRepository.GetCaster<SelfCaster>().Cast(_healSpell, errorPercent),
                        (errorPercent) => _castersRepository.GetCaster<SelfCaster>().Cast(_healSpell, errorPercent),
                        (errorPercent) => _castersRepository.GetCaster<SelfCaster>().Cast(_healSpell, errorPercent),
                        (errorPercent) => _castersRepository.GetCaster<SelfCaster>().Cast(_healSpell, errorPercent),
                    }
                }
            };
        }
    }
    
}