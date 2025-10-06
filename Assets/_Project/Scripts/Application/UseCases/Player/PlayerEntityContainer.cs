using _Project.Scripts.Domain.Services;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Application.UseCases.Player
{
    public class PlayerEntityContainer: MonoBehaviour
    {
        public MelodyReplacer MelodyReplacer { get; private set; }

        [Inject]
        public void Construct(MelodyReplacer melodyReplacer)
        {
            MelodyReplacer = melodyReplacer;
        }
    }
}