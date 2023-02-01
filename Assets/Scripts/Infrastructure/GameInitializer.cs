using UnityEngine;


namespace Scripts.Infrastructure
{
    public class GameInitializer : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();

            DontDestroyOnLoad(this);
        }
    }
}

