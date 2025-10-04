namespace _Project.Scripts.Domain.Entities
{
    public struct Note
    {
        public int NoteIndex { get; }

        public Note(int noteIndex)
        {
            NoteIndex = noteIndex;
        }
    }
}