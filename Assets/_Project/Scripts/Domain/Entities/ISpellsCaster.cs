using System.Collections.Generic;

namespace _Project.Scripts.Domain.Entities
{
    public interface ISpellsCaster
    {
        void CastSpell(List<Tact> melody);
    }
}