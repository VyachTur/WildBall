using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private Text _score;

        public void ShowScore(int pointsCount)
        {
            _score.text = $"Осталось собрать: {pointsCount}";
        }
    }
}
