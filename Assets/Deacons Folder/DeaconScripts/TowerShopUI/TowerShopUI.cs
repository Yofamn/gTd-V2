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

        if (PlayerNumManager.Instance.GetCoins() >= towerCost)
        {


            // Find the DeaconsCursor and set its towerPrefab
            DeaconsCursor deaconsCursor = FindObjectOfType<DeaconsCursor>();
            if (deaconsCursor != null)
            {
                // If towerPrefab is already set to this tower, do nothing to avoid resetting it
                if (deaconsCursor.towerPrefab != towerPrefab)
                {
                    deaconsCursor.towerPrefab = towerPrefab;  // Set the selected tower
                }
            }

            // Optionally update UI to show the currently selected tower
            // You can add any logic here to show the selected tower in the UI, like a preview or highlighting it
        }
        else
        {
            Debug.Log("Not enough gold!");
        }
    }


    }
}