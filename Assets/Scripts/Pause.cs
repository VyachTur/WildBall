using UnityEngine;

namespace Scripts
{
    public class Pause : MonoBehaviour
    {
        public void DoPause(bool setter) => Time.timeScale = setter ? 0f : 1f;
    }
}

