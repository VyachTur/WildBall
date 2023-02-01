using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts
{
    [Serializable]
    public class BoolEvent : UnityEvent<bool> { };

    public class ActivateCubeMarker : MonoBehaviour
    {
        [SerializeField] private BoolEvent _playerEnterAreaEvent;
        [SerializeField] private Animator _objectToActivateAnimator;

        private Player _player;

        private void Start()
        {
            _player = FindObjectOfType<Player>();

            _player.PlayerActionEvent += ActivateObject;
        }

        public void ActivateObject()
        {
            _objectToActivateAnimator?.SetTrigger("DoOpenDoor");
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out _))
            {
                _playerEnterAreaEvent.Invoke(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Player>(out _))
            {
                _playerEnterAreaEvent.Invoke(false);
            }
        }
    }
}

