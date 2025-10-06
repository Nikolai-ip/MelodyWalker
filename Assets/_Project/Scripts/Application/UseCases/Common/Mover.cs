using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.Application.UseCases
{
    public class Mover : MonoBehaviour
    {
        private Transform _transform;
        
        [SerializeField] private float _acceleration = 10f;
        [SerializeField] private float _deceleration = 15f;
        [SerializeField] private float _decelerationThreshold = 0.1f;
        [SerializeField] private float _velPower = 1.5f;
        
        [SerializeField] private Rigidbody _rb;

        public float Speed = 3f;

        private void Awake() => _transform = transform;
        
        public void MoveTo(Vector3 target)
        {
            Vector3 targetVelocity = (target - _transform.position).normalized * Speed;
            Vector3 velocityDelta = targetVelocity - _rb.linearVelocity;

            float accelRate = (velocityDelta.magnitude > _decelerationThreshold) ? _acceleration : _deceleration;

            Vector3 poweredDiff = new(
                Mathf.Pow(Mathf.Abs(velocityDelta.x), _velPower) * Mathf.Sign(velocityDelta.x),
                Mathf.Pow(Mathf.Abs(velocityDelta.y), _velPower) * Mathf.Sign(velocityDelta.y),
                Mathf.Pow(Mathf.Abs(velocityDelta.z), _velPower) * Mathf.Sign(velocityDelta.z)
            );

            Vector3 force = poweredDiff * (accelRate * Time.fixedDeltaTime);

            _rb.AddForce(force, ForceMode.VelocityChange);
            
            // if (_rb.linearVelocity.magnitude > _speed)
            //     _rb.linearVelocity = _rb.linearVelocity.normalized * _speed;
        }
    }
}