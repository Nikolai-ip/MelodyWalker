namespace _Project.Scripts.Domain.Rules
{
    public class CalcMelodyErrorsRule
    {
        public float AllowedErrorPercentage { get; }
        public float IgnoredErrorPercentageForNote { get; }
        public float WrongNoteErrorWeight { get; }
        public float MaxWrongIntervalWeight { get; }

        public CalcMelodyErrorsRule(float allowedErrorPercentage, float ignoredErrorPercentageForNote, float wrongNoteErrorWeight, float maxWrongIntervalWeight)
        {
            AllowedErrorPercentage = allowedErrorPercentage;
            IgnoredErrorPercentageForNote = ignoredErrorPercentageForNote;
            WrongNoteErrorWeight = wrongNoteErrorWeight;
            MaxWrongIntervalWeight = maxWrongIntervalWeight;
        }
    }
}