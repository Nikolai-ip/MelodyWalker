using System;
using System.Collections.Generic;

namespace _Project.Scripts.Domain.Entities
{
    public class Tact
    {
        public List<Tuple<float, Note>> ReferenceNoteIntervals { get; }
        public Tact(List<Tuple<float, Note>> referenceNoteIntervals)
        {
            ReferenceNoteIntervals = referenceNoteIntervals;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                foreach (var (interval, note) in ReferenceNoteIntervals)
                {
                    hash = hash * 31 + interval.GetHashCode();
                    hash = hash * 31 + note.GetHashCode();
                }
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is not Tact other)
                return false;

            if (ReferenceNoteIntervals.Count != other.ReferenceNoteIntervals.Count)
                return false;

            for (int i = 0; i < ReferenceNoteIntervals.Count; i++)
            {
                if (ReferenceNoteIntervals[i].Item1 != other.ReferenceNoteIntervals[i].Item1)
                    return false;
                if (!ReferenceNoteIntervals[i].Item2.Equals(other.ReferenceNoteIntervals[i].Item2))
                    return false;
            }

            return true;
        }
    }
}