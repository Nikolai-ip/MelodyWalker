using UnityEngine;

namespace _Project.Scripts.Presentation
{
    public class ExitFromGame : MonoBehaviour
    {
        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}