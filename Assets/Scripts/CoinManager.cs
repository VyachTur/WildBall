using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class CoinManager : MonoBehaviour
    {
        [SerializeField] private Coin _coin;
        [SerializeField] private List<GameObject> _coinsList;


        public void CollectCoin(GameObject coin)
        {
            if (coin.TryGetComponent(out Coin currentCoin))
            {
                _coinsList.Remove(coin);
                currentCoin.Collect();
            }
        }

        public GameObject NearestCoin(Vector3 point)
        {
            if (_coinsList.Count <= 0) return null;

            GameObject nearestCoin = _coinsList[0];
            float minDistance = Mathf.Infinity;

            foreach (var coin in _coinsList)
            {
                var distance = Vector3.Distance(point, coin.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestCoin = coin;
                }
            }

            return nearestCoin;
        }
    }
}

