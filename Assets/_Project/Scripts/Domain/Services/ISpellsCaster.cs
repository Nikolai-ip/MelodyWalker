using System.Collections.Generic;
using _Project.Scripts.Domain.Entities;

namespace _Project.Scripts.Domain.Services
{
    public interface ISpellsCaster
    {
        void CastSpell(List<Tact> melody);
    }
}