using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Zenject;

namespace _Project.Scripts.Infrastructure.Input
{
    public class TestInput : MonoBehaviour
    {
        private IInputService _inputService;
            
        [Inject]
        private void Construct(IInputService inputService) => _inputService = inputService;

        private void Start()
        {
            _inputService.NotePressed += note => Debug.Log(note); 
            _inputService.CastApplied += () => Debug.Log($"Cast Applied");
            _inputService.CastCancelled += () => Debug.Log($"Cast cancelled");
        }

        private void Update()
        {
            Debug.Log(_inputService.MouseScreenPosition);
        }
    }
}