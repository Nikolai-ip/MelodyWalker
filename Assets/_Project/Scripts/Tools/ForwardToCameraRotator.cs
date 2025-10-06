using UnityEngine;

public class ForwardToCameraRotator : MonoBehaviour
{
    private Camera _camera;
    private Transform _transform;

    private void Awake()
    {
        _camera = Camera.main;
        _transform = transform;
    }

    private void Update() => RotateToCamera();

    private void RotateToCamera() => _transform.forward = -Vector3.Normalize(_camera.transform.position - _transform.position);
}