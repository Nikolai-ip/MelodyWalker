using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Core.DI
{
    public class InstallerBundle: MonoInstaller
    {
        [SerializeField] protected List<SubInstaller> _installers;
        public override void InstallBindings()
        {
            _installers.ForEach(installer=>installer.InstallBindings(Container));
        }
    }
}