namespace _Project.Scripts.Domain.Entities
{
    public class Note
    {
        public int NoteIndex { get; }

        public Note(int noteIndex)
        {
            NoteIndex = noteIndex;
        }
        public override int GetHashCode()
        {
            return NoteIndex.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return obj is Note other && NoteIndex == other.NoteIndex;
        }
    }
}