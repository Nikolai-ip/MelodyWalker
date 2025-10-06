using System.Collections.Generic;
using _Project.Scripts.Domain.Entities;

namespace _Project.Scripts.Domain.Repositories
{
    public class MelodyRepository
    {
        public List<Melody> Melodies { get; }
        public MelodyRepository(List<Melody> melodies)
        {
            Melodies = melodies;
        }
    }

    public class PlayerMelodyRepository : MelodyRepository
    {
        public PlayerMelodyRepository(List<Melody> melodies) : base(melodies) { }
    }
}