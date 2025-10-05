using _Project.Scripts.Domain.Entities;
using UnityEngine;

namespace _Project.Scripts.Application.UseCases.SpellCasters
{
    public class AreaCaster : Caster
    {
        [SerializeField] private float _areaRadius;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private LayerMask _layerMask;
        
        private Collider[] _collidersBuffer = new Collider[10];

        public override void Cast<TTarget>(ISpell<TTarget> spell) 
        {
            int amountInArea = Physics.OverlapSphereNonAlloc(_playerTransform.position, _areaRadius, _collidersBuffer, _layerMask);

            for (int i = 0; i < amountInArea; i++)
            {
                if (!_collidersBuffer[i].TryGetComponent(out TTarget target))
                {
                    Debug.LogWarning($"No target found in {_collidersBuffer[i].name}");
                    continue;
                }
                
                spell.Apply(target);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_playerTransform.position, _areaRadius);
        }
    }
}