using UnityEngine;

namespace Scripts
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private GameObject _coinView;
        [SerializeField] private GameObject _collectEffect;
        [SerializeField] private GameObject _viewEffect;

        private void Start()
        {
            _collectEffect.gameObject.SetActive(false);
            _viewEffect.gameObject.SetActive(true);
        }

        public void Collect()
        {
            _coinView.SetActive(false);
            _collectEffect.gameObject.SetActive(true);
            _viewEffect.gameObject.SetActive(false);

            Destroy(gameObject, 2f);
        }
    }
}

