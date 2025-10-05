using System.Collections.Generic;
using _Project.Scripts.Domain.Entities;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "StaticData/MelodyRepository", fileName = "MelodyRepository")]
    public class MelodyRepository_SO: ScriptableObject
    {
        [field: SerializeField] public List<Melody_SO> Melodies { get; private set; }

        public List<Melody> GetMelodies()
        {
            var result =  new List<Melody>();
            foreach (var melody in Melodies)
            {
                result.Add(melody.GetMelody());
            }

            return result;
        }
    }


}