using _Game.Scripts.Services.Audio.Music.Components;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Project.Scripts.Application.UseCases.Audio
{
    public class SceneMusicPackOnStartRunner:IInitializable
    {
        private readonly SceneMusicPackSwitcher _sceneMusicPackSwitcher;
        
        public SceneMusicPackOnStartRunner(SceneMusicPackSwitcher sceneMusicPackSwitcher)
        {
            _sceneMusicPackSwitcher = sceneMusicPackSwitcher;
        }

        public void Initialize()
        {
            _sceneMusicPackSwitcher.PlaySceneMusicPack(SceneManager.GetActiveScene().name);
        }
    }
}