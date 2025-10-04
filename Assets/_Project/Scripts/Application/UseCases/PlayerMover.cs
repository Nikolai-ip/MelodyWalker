using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Infrastructure.Input;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Application.UseCases
{
    public class PlayerMover : MonoBehaviour
    {
        private const int MaxMouseHits = 10;
        private readonly RaycastHit[] _rayCastHits = new RaycastHit[MaxMouseHits];

        private IInputService _inputService;
        
        private Vector3 _target;
        private Transform _transform;
        
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _offset;

        [Inject]
        private void Construct(IInputService inputService) => _inputService = inputService;

        private void Awake() => _transform = transform;

        private void Update()
        {
            CalculateTarget();
            
            MoveToTarget();
        }

        private void CalculateTarget()
        {
            var currentMousePos = _inputService.MouseScreenPosition;
            
            Ray ray = Camera.main.ScreenPointToRay(currentMousePos);
            
            int hitsCount = Physics.RaycastNonAlloc(ray, _rayCastHits);
            
            if (hitsCount == 0)
                return;

            RaycastHit? currentHit = null;  
            
            foreach (var hit in _rayCastHits)
            {
                if (hit.collider.TryGetComponent(out Ground ground))
                {
                    currentHit = hit;
                    break;
                }
            }

            if (!currentHit.HasValue)
                return;

            _target = currentHit.Value.point;
        }

        private void MoveToTarget()
        {
            _transform.position = Vector3.Lerp(_transform.position, _target + _offset, _speed * Time.deltaTime);
            // var offsetTarget = _transform.position + _target + _offset;
            // _transform.Translate( offsetTarget * (_speed * Time.deltaTime));
        }
    }
}