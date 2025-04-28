using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace TowerDefense
{
    public class TowerShopUI : MonoBehaviour
    {
        [SerializeField] private List<Button> towerButtons;
        [SerializeField] private List<GameObject> towerPrefabs; // Prefabs that already have Tower script attached

        private void Start()
        {
            for (int i = 0; i < towerButtons.Count; i++)
            {
                int index = i;
                towerButtons[i].onClick.AddListener(() => AttemptToBuyTower(index));
            }
        }

        private void AttemptToBuyTower(int index)
        {
            GameObject towerPrefab = towerPrefabs[index];
            int towerCost = Tower_SO.GetCost(towerPrefab);

            if (CoinManager.Instance.GetCoins() >= towerCost)
            {
                CoinManager.Instance.SpendCoins(towerCost); // Spend coins

                Player player = FindObjectOfType<Player>();

                if (player != null)
                {
                    player.towerPrefab = towerPrefab;
                }
            }
            else
            {
                Debug.Log("Not enough gold!");
            }
        }
    }
}