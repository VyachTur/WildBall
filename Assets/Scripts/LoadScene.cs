using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class LoadScene : MonoBehaviour
    {
        [SerializeField] private int _sceneIndex = 0;

        public void Load() => SceneManager.LoadScene(_sceneIndex);
    }
}

