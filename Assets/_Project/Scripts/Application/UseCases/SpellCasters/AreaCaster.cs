using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Entities.Spells;
using UnityEngine;

namespace _Project.Scripts.Application.UseCases.SpellCasters
{
    public class AreaCaster : Caster
    {
        private Collider[] _collidersBuffer = new Collider[10];

        [SerializeField] private float _areaRadius;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private LayerMask _layerMask;
        
        [SerializeField] private GameObject _damageEffect;

        public override void Cast<TTarget>(ISpell spell, float errorPercent) 
        {
            //todo: Error Percent
            int amountInArea = Physics.OverlapSphereNonAlloc(_playerTransform.position, _areaRadius, _collidersBuffer, _layerMask);

            for (int i = 0; i < amountInArea; i++)
            {
                if (!_collidersBuffer[i].TryGetComponent(out TTarget target))
                {
                    Debug.LogWarning($"No target found in {_collidersBuffer[i].name}");
                    continue;
                }
                
                spell.Apply(target.gameObject, errorPercent);
            }

            if (spell is DamageSpell)
            {
                Instantiate(_damageEffect, _playerTransform.position, _playerTransform.rotation);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_playerTransform.position, _areaRadius);
        }
    }
}