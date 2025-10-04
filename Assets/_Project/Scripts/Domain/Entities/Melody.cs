using System.Collections.Generic;

namespace _Project.Scripts.Domain.Entities
{
    public struct Melody
    {
        public List<Tact> Tacts { get; }

        public Melody(List<Tact> tacts)
        {
            Tacts = tacts;
        }
    }
}