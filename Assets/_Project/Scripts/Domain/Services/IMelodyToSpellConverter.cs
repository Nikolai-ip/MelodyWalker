using System.Collections.Generic;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Entities.Spells;

namespace _Project.Scripts.Domain.Services
{
    public interface IMelodyToSpellConverter
    {
        ISpell<TData> Convert<TData>(List<Tact> melody);
    }
}