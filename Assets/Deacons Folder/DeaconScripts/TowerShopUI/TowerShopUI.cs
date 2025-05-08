using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace TowerDefense
{
    public class TowerShopUI : MonoBehaviour
    {
        [SerializeField] private List<Button> towerButtons;
        [SerializeField] private List<GameObject> towerPrefabs;

        private void Start()
        {
            for (int i = 0; i < towerButtons.Count; i++)
            {
                int index = i;
                towerButtons[i].onClick.AddListener(() => OnTowerButtonClicked(index));
            }
        }

        private void OnTowerButtonClicked(int index)
        {
            GameObject selectedPrefab = towerPrefabs[index];
            int cost = Tower_SO.GetCost(selectedPrefab);

            if (PlayerNumManager.Instance.GetCoins() < cost)
            {
                Debug.Log("Not enough coins to select this tower.");
                return;
            }

            // Select tower in TowerButtonController
            TowerButtonController.Instance.UpdateSelection(towerButtons[index], selectedPrefab);

            // Set selected prefab in DeaconsCursor
            DeaconsCursor cursor = FindObjectOfType<DeaconsCursor>();
            if (cursor != null)
            {
                cursor.selectedTower = selectedPrefab;
            }
        }
    }
}
