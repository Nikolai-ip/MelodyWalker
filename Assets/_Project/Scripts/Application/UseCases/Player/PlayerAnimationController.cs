using UnityEngine;

namespace _Project.Scripts.Application.UseCases.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        private Animator _animator;

        private static readonly int WalkForward = Animator.StringToHash("WalkForward");
        private static readonly int WalkBackward = Animator.StringToHash("WalkBackward");
        private static readonly int WalkLeft = Animator.StringToHash("WalkLeft");
        private static readonly int WalkRight = Animator.StringToHash("WalkRight");

        [SerializeField] private float idleThreshold = 0.1f;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Vector3 velocity = _rb.linearVelocity;

            // Если стоим
            if (velocity.magnitude < idleThreshold)
            {
                ResetAnimations();
                return;
            }

            // Получаем направление относительно персонажа
            Vector3 localVelocity = transform.InverseTransformDirection(velocity).normalized;

            // Определяем доминирующее направление
            if (Mathf.Abs(localVelocity.x) > Mathf.Abs(localVelocity.z))
            {
                if (localVelocity.x > 0)
                    PlayAnimation(WalkRight);
                else
                    PlayAnimation(WalkLeft);
            }
            else
            {
                if (localVelocity.z > 0)
                    PlayAnimation(WalkForward);
                else
                    PlayAnimation(WalkBackward);
            }
        }

        private void PlayAnimation(int animHash)
        {
            ResetAnimations();
            _animator.SetBool(animHash, true);
        }

        private void ResetAnimations()
        {
            _animator.SetBool(WalkForward, false);
            _animator.SetBool(WalkBackward, false);
            _animator.SetBool(WalkLeft, false);
            _animator.SetBool(WalkRight, false);
        }
    }
}