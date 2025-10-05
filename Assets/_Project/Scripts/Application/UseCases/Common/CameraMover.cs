using UnityEngine;

namespace _Project.Scripts.Application.UseCases.Common
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _speed;

        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _target;

        private void Update()
        {
            var target = new Vector3(_target.position.x, 0f, _target.position.z);
            
            _camera.position = Vector3.Lerp(_camera.transform.position, target + _offset, Time.deltaTime * _speed);    
        }
    }
}