using System.Collections.Generic;
using _Project.Scripts.Domain.Entities;

namespace _Project.Scripts.Domain.Services
{
    public interface IMelodyToSpellConverter
    {
        ISpell<TData> Convert<TData>(List<Tact> melody);
    }
}