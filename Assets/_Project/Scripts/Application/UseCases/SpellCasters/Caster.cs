using System;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Entities.Spells;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.Application.UseCases.SpellCasters
{
    public abstract class Caster : MonoBehaviour
    {
        public abstract void Cast<TTarget>(ISpell spell, float errorPercent) where TTarget : Component;
    }
    
    public class BulletCaster : Caster
    {
        // [SerializeField] private BulletSpell _bulletPrefab;
        
        public override void Cast<TTarget>(ISpell spell, float errorPercent)
        {
            
        }
    }

    // public class BulletSpell 
    
    public class BulletSpell<TTarget> : MonoBehaviour
    {
        private ISpell _spell;

        public void Construct(ISpell spell) => _spell = spell;

        private void OnCollisionEnter(Collision other)
        {
            Destroy(this.gameObject);

            if (!other.gameObject.TryGetComponent(out TTarget target)) 
                return;
            
            
        }
    }
}