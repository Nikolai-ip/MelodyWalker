namespace _Project.Scripts.Domain.ValueObjects
{
    [System.Flags]
    public enum Note
    {
        None = 0,
        Note1 = 1 << 1,
        Note2 = 1 << 2,
        Note3 = 1 << 3,
        Note4 = 1 << 4,
        Note5 = 1 << 5,
        Note6 = 1 << 6,
        Note7 = 1 << 7,
    }
}