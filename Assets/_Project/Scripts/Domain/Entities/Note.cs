namespace _Project.Scripts.Domain.Entities
{
    public class Note
    {
        public int NoteIndex { get; }

        public Note(int noteIndex)
        {
            NoteIndex = noteIndex;
        }
    }
}