using System;
using System.Collections.Generic;
using _Project.Scripts.Application.UseCases.Enemy;
using _Project.Scripts.Application.UseCases.SpellCasters;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Entities.HealthSystem;
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
        private readonly DashSpell _dashSpell = new();
        private readonly DashSpell _invisibleSpell = new();
        
        
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
                            areaCaster.Cast<EnemyController>(_damageSpell, errorPercent);
                            Debug.Log("DAMAGE");
                        },
                        (errorPercent) =>
                        {
                            areaCaster.Cast<EnemyController>(_damageSpell, errorPercent);
                            Debug.Log("DAMAGE");
                        },
                        (errorPercent) =>
                        {
                            areaCaster.Cast<EnemyController>(_damageSpell, errorPercent);
                            Debug.Log("DAMAGE");
                        },
                        (errorPercent) =>
                        {
                            areaCaster.Cast<EnemyController>(_damageSpell, errorPercent);
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
                            selfCaster.Cast<Health>(_healSpell, errorPercent);
                            Debug.Log("HEAL");
                        },
                        (errorPercent) =>
                        {
                            selfCaster.Cast<Health>(_healSpell, errorPercent);
                            Debug.Log("HEAL");
                        },
                        (errorPercent) =>
                        {
                            selfCaster.Cast<Health>(_healSpell, errorPercent);
                            Debug.Log("HEAL");
                        },
                        (errorPercent) =>
                        {
                            selfCaster.Cast<Health>(_healSpell, errorPercent);
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
                            selfCaster.Cast<Health>(_dashSpell, errorPercent);
                            Debug.Log("DASH");
                        },
                        (errorPercent) =>
                        {
                            selfCaster.Cast<Health>(_protectSpell, errorPercent);
                            Debug.Log("PROTECT");
                        },
                        (errorPercent) =>
                        {
                            selfCaster.Cast<Health>(_invisibleSpell, errorPercent);
                            Debug.Log("INVISBLE");
                        },                        
                        (errorPercent) =>
                        {
                            selfCaster.Cast<Health>(_protectSpell, errorPercent);
                            Debug.Log("PROTECT");
                        },
                    }
                },
            };
        }
    }
    
}