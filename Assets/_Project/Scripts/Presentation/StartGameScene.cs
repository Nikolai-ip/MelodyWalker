using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Presentation
{
    public class StartGameScene : MonoBehaviour
    {
        public void LoadGameScene() => SceneManager.LoadScene("UIDevScene");
    }
}