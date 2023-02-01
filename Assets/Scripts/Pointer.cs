using UnityEngine;

namespace Scripts
{
    public class Pointer : MonoBehaviour
    {
        [SerializeField] private CoinManager _coinManager;
        [SerializeField] private Player _player;

        private GameObject _nearestCoin;

        private void Update()
        {
            transform.position = new Vector3(_player.transform.position.x, 
                                             _player.transform.position.y + 0.685f, 
                                             _player.transform.position.z - 0.076f);

            _nearestCoin = _coinManager.NearestCoin(transform.position);

            if (!_nearestCoin) return;

            transform.rotation = Quaternion.LookRotation(ToTarget(_nearestCoin.transform.position));

#if UNITY_EDITOR
            Debug.DrawLine(transform.position, _nearestCoin.transform.position);
#endif

        }

        private Vector3 ToTarget(Vector3 target)
        {
            Vector3 toTarget = target - transform.position;
            Vector3 toTargetXZ = new Vector3(toTarget.x, 0, toTarget.z);

            return toTargetXZ;
        }
    }
}