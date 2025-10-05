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
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                foreach (var tact in Tacts)
                {
                    hash = hash * 31 + tact.GetHashCode();
                }
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is not Melody other)
                return false;

            if (Tacts.Count != other.Tacts.Count)
                return false;

            for (int i = 0; i < Tacts.Count; i++)
            {
                if (!Tacts[i].Equals(other.Tacts[i]))
                    return false;
            }

            return true;
        }
    }
}