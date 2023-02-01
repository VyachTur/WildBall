using UnityEngine;


namespace Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private Transform _cameraLook;
        [SerializeField] private float _torqueForwardSpeed = 58f;
        [SerializeField] private float _torqueSideSpeed = 30f;


        private Rigidbody _playerRigidBody;
        private PlayerInput _playerInput;
        private float _speedLerp;

        private void Start()
        {
            _playerRigidBody = GetComponent<Rigidbody>();
            _playerInput = GetComponent<PlayerInput>();

            _playerRigidBody.maxAngularVelocity = Constants.MaxAngularVelocity;
        }

        private void FixedUpdate()
        {
            _speedLerp = Mathf.Lerp(_speedLerp, _playerInput.Forward, Time.fixedDeltaTime * Constants.PlayerSpeedCoefficient);

            _playerRigidBody.AddTorque(_cameraLook.right * _speedLerp * _torqueForwardSpeed);
            _playerRigidBody.AddTorque(-_cameraLook.forward * _playerInput.Sideways * _torqueSideSpeed);
        }
    }
}