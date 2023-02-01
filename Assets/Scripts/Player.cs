using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts
{
    public class Player : MonoBehaviour
    {
        public event Action PlayerActionEvent;

        [SerializeField] private CoinManager _coinManager;
        [SerializeField] private ParticleSystem _deathEffect;
        [SerializeField] private GameObject _playerRenderer;
        [SerializeField] private GameObject _pointerRenderer;
        //[SerializeField] private ScoreManager ScoreManager;

        private bool _isPlayerDeath = false;

        public bool IsPlayerDeath => _isPlayerDeath;

        private PlayerInput _playerInput;

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();

            //ScoreManager.ShowScore(CoinManager.CoinsCount);

            //PlayerTurnedYellow(0.9f);
        }

        private void Update()
        {
            if (_playerInput.IsActivate) PlayerActionEvent?.Invoke();
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<DeathCubeMarker>(out _))
            {
                PlayerDeath();
            }


            if (other.gameObject.tag == "Coin")
            {
                _coinManager.CollectCoin(other.gameObject);
                //ScoreManager.ShowScore(CoinManager.CoinsCount);


            }
        }

        private void PlayerTurnedYellow(float percent)
        {
            if (percent < 0f || percent > 1f) return;

            _playerRenderer.GetComponent<Renderer>().material.SetColor("_Color", new Color(1, 1, percent, 1));
        }

        private void PlayerDeath()
        {
            _isPlayerDeath = true;

            _playerRenderer.SetActive(false);
            _pointerRenderer.SetActive(false);
            _deathEffect.Play();

            Destroy(gameObject, 5f);
        }
    }
}

