using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Repositories;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Application.UseCases.Common
{
    public class SpellCheating : ITickable
    {
        private SpellDataRepository _spellRepository;
        private readonly List<Melody> _keys;

        [Inject]
        public SpellCheating(SpellDataRepository spellRepository)
        {
            _spellRepository = spellRepository;
            _keys = _spellRepository.Spells.Keys.Select(keys=>keys.Item1).ToList();
        }

        public void Tick()
        {
// # if UNITY_EDITOR
//
//             for (int i = (int)KeyCode.F1; i <= (int)KeyCode.F12; i++)
//             {
//                 if (Input.GetKeyDown((KeyCode)i))
//                 {
//                     int index = i - (int)KeyCode.F1;
//                     _spellRepository.Spells[_keys[index / 4]][index % 4](0f);    
//                     Debug.Log(index);                    
//                 }
//             }
//             
// # endif
        }
    }
}