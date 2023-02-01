using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class ReturnMainMenu : MonoBehaviour
    {
        public void LoadMainManuScene() => SceneManager.LoadScene(0);
    }
}

