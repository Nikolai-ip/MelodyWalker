using System;
using _Project.Scripts.Domain.Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.Application.UseCases.SpellCasters
{
    public abstract class Caster : MonoBehaviour
    {
        public abstract void Cast<TTarget>(ISpell<TTarget> spell);
    }
    
    public class BulletCaster : Caster
    {
        // [SerializeField] private BulletSpell _bulletPrefab;

        public override void Cast<TTarget>(ISpell<TTarget> spell)
        {
            // BulletSpell bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            //
            // bullet 
        }
    }

    // public class BulletSpell 
    
    public class BulletSpell<TTarget> : MonoBehaviour
    {
        private ISpell<TTarget> _spell;

        public void Construct(ISpell<TTarget> spell) => _spell = spell;

        private void OnCollisionEnter(Collision other)
        {
            Destroy(this.gameObject);

            if (!other.gameObject.TryGetComponent(out TTarget target)) 
                return;
            
            
        }
    }
}