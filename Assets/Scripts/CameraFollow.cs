using UnityEngine;

namespace Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _cameraMoveSpeed;

        private Rigidbody _playerRB;

        private void Start()
        {
            _playerRB = _player.gameObject.GetComponent<Rigidbody>();
        }

        private void LateUpdate()
        {
            if (_player.IsPlayerDeath) return;

            transform.position = Vector3.Lerp(transform.position, _player.transform.position, _cameraMoveSpeed * Time.deltaTime);

            if (_playerRB.velocity.magnitude > Constants.Epsilon)
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_playerRB.velocity), 
                                                        Time.deltaTime * Constants.CameraRotateSpeedCoefficient);
        }
    }
}

