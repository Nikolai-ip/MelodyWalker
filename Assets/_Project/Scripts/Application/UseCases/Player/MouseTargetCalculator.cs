using System;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Infrastructure.Input;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Application.UseCases.Player
{
    public class MouseTargetCalculator : MonoBehaviour
    {
        private const int MaxMouseHits = 10;
        private readonly RaycastHit[] _rayCastHits = new RaycastHit[MaxMouseHits];

        private IInputService _inputService;

        [SerializeField] private Transform _playerTransform;
        
        public Vector3 Target { get; private set; }
        
        [Inject]
        private void Construct(IInputService inputService) => _inputService = inputService;

        private void Awake() => Target = _playerTransform.position;

        private void Update() => CalculateTarget();

        private void CalculateTarget()
        {
            var currentMousePos = _inputService.MouseScreenPosition;
            
            Ray ray = Camera.main.ScreenPointToRay(currentMousePos);
            
            int hitsCount = Physics.RaycastNonAlloc(ray, _rayCastHits);
            
            if (hitsCount == 0)
                return;

            RaycastHit? currentHit = null;
            
            foreach (RaycastHit hit in _rayCastHits)
            {
                if (hit.collider == null)
                    continue;
                
                if (hit.collider.TryGetComponent(out Ground ground))
                {
                    currentHit = hit;
                    break;
                }
            }

            if (!currentHit.HasValue)
                return;
            
            Target = currentHit.Value.point;
        }
    }
}