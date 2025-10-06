using System;
using System.Collections.Generic;
using _Project.Scripts.Application.UseCases.SpellCasters;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Entities.Spells;
using UnityEngine;

namespace _Project.Scripts.Domain.Repositories
{
    public class SpellDataRepository
    {
        private readonly CastersRepository _castersRepository;
        
        private readonly HealSpell _healSpell = new();
        private readonly DamageSpell _damageSpell = new();
        private readonly ProtectSpell _protectSpell = new();
        
        
        private readonly Dictionary<MelodyType,Melody> _melodies;

        public Dictionary<Melody, List<Action<float>>> Spells { get; }

        public SpellDataRepository(Dictionary<MelodyType, Melody> melodies, CastersRepository castersRepository)
        {
            _melodies = melodies;
            
            _castersRepository = castersRepository;

            var areaCaster = _castersRepository.GetCaster<AreaCaster>();
            var selfCaster = _castersRepository.GetCaster<SelfCaster>();
            
            Spells = new Dictionary<Melody, List<Action<float>>>()
            {
                {
                    _melodies[MelodyType.Damage],
                    new List<Action<float>>()
                    {
                        (errorPercent) =>
                        {
                            areaCaster.Cast(_damageSpell, errorPercent);
                            Debug.Log("DAMAGE");
                        },
                        (errorPercent) =>
                        {
                            areaCaster.Cast(_damageSpell, errorPercent);
                            Debug.Log("DAMAGE");
                        },
                        (errorPercent) =>
                        {
                            areaCaster.Cast(_damageSpell, errorPercent);
                            Debug.Log("DAMAGE");
                        },
                        (errorPercent) =>
                        {
                            areaCaster.Cast(_damageSpell, errorPercent);
                            Debug.Log("DAMAGE");
                        },
                    }
                },
                {
                    _melodies[MelodyType.Heal],
                    new List<Action<float>>()
                    {
                        (errorPercent) =>
                        {
                            selfCaster.Cast(_healSpell, errorPercent);
                            Debug.Log("HEAL");
                        },
                        (errorPercent) =>
                        {
                            selfCaster.Cast(_healSpell, errorPercent);
                            Debug.Log("HEAL");
                        },
                        (errorPercent) =>
                        {
                            selfCaster.Cast(_healSpell, errorPercent);
                            Debug.Log("HEAL");
                        },
                        (errorPercent) =>
                        {
                            selfCaster.Cast(_healSpell, errorPercent);
                            Debug.Log("HEAL");
                        },
                    }
                },
                {
                    _melodies[MelodyType.Protect],
                    new List<Action<float>>()
                    {
                        (errorPercent) =>
                        {
                            selfCaster.Cast(_protectSpell, errorPercent);
                            Debug.Log("PROTECT");
                        },
                        (errorPercent) =>
                        {
                            selfCaster.Cast(_protectSpell, errorPercent);
                            Debug.Log("PROTECT");
                        },
                        (errorPercent) =>
                        {
                            selfCaster.Cast(_protectSpell, errorPercent);
                            Debug.Log("PROTECT");
                        },                        (errorPercent) =>
                        {
                            selfCaster.Cast(_protectSpell, errorPercent);
                            Debug.Log("PROTECT");
                        },
                    }
                },
            };
        }
    }
    
}