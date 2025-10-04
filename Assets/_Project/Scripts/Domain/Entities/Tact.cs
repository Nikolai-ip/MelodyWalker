using System;
using System.Collections.Generic;

namespace _Project.Scripts.Domain.Entities
{
    public struct Tact
    {
        public List<Tuple<float, Note>> ReferenceNoteIntervals { get; }
        public Tact(List<Tuple<float, Note>> referenceNoteIntervals)
        {
            ReferenceNoteIntervals = referenceNoteIntervals;
        }
    }
}