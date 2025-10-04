using System.Collections.Generic;

namespace _Project.Scripts.Domain.Entities
{
    public class Melody
    {
        public List<Tact> Tacts { get; }

        public Melody(List<Tact> tacts)
        {
            Tacts = tacts;
        }
    }
}