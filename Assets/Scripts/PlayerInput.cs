using Scripts.Infrastructure;
using Scripts.Services.Inputs;
using UnityEngine;

namespace Scripts
{
    public class PlayerInput : MonoBehaviour
    {
        public float Forward => _playerInputAxis.y;
        public float Sideways => _playerInputAxis.x;
        public bool IsActivate => _isActivate;

        private Vector2 _playerInputAxis;
        private IInputService _inputService;
        private bool _isActivate;

        private void Awake()
        {
            _inputService = Game.InputService;
        }

        private void Update()
        {
            _playerInputAxis = new Vector2(_inputService.Axis.x, _inputService.Axis.y).normalized;
            _isActivate = _inputService.IsActivateButtonUp();
        }
    }
}

