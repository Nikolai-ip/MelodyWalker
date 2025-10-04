using _Project.Scripts.Domain.Rules;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "Configs/CalcMelodyErrorRule", fileName = "CalcMelodyErrorRule")]
    public class CalcMelodyErrorRule_SO: ScriptableObject
    {
        [field: SerializeField] public float MaxWrongIntervalWeight { get; set; }
        [field: SerializeField] public float IgnoredErrorPercentageForNote { get; set; }
        [field: SerializeField] public float AllowedErrorPercentage { get; set; }
        [field: SerializeField] public float WrongNoteErrorWeight { get; set; }

        public CalcMelodyErrorsRule GetInstance()
        {
            return new CalcMelodyErrorsRule(
                AllowedErrorPercentage,
                IgnoredErrorPercentageForNote,
                WrongNoteErrorWeight,
                MaxWrongIntervalWeight);
        }
    }
}