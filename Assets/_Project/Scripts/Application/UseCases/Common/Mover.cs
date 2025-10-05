using UnityEngine;

namespace _Project.Scripts.Application.UseCases
{
    public class Mover : MonoBehaviour
    {
        private Transform _transform;
        
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _offset;
        
        private void Awake() => _transform = transform;

        public void MoveTo(Vector3 target)
        {
            _transform.position = Vector3.Lerp(_transform.position, target + _offset, _speed * Time.deltaTime);
            // var offsetTarget = _transform.position + _target + _offset;
            // _transform.Translate( offsetTarget * (_speed * Time.deltaTime));
        }
    }
}