using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Application.UseCases.SpellCasters;

namespace _Project.Scripts.Domain.Repositories
{
    public class CastersRepository
    {
        private readonly Dictionary<Type, Caster> _casters;

        public CastersRepository(List<Caster> casters)
        {
            _casters = casters.ToDictionary(caster=> caster.GetType(), caster=>caster);
        }


        public Caster GetCaster<TCaster>()
        {
            if (_casters.TryGetValue(typeof(TCaster), out Caster caster))
            {
                return caster;
            }
            throw new Exception($"Caster {typeof(TCaster)} not found");
        }
    }
}