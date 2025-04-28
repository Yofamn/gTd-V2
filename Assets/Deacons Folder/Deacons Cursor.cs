using System.Collections;
using System.Collections.Generic;
using TowerDefence;
using UnityEngine;

namespace TowerDefense{
    public class DeaconsCursor : MonoBehaviour
    {
        public GameObject towerPrefab;
        private MyGrid grid;
        private Cursor cursor;

        private void Awake()
        {
            grid = FindObjectOfType<MyGrid>();
            cursor = GetComponent<Cursor>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3Int tileCoords = MyGrid.WorldToGrid(cursor.transform.position);
                TryPlaceTower(grid, tileCoords);
            }
        }

        public bool TryPlaceTower(MyGrid grid, Vector3Int tileCoords)
        {
            int towerCost = Tower_SO.GetCost(towerPrefab);

            if (CoinManager.Instance.GetCoins() < towerCost) return false;
            if (grid.Occupied(tileCoords)) return false;

            // Get center of the tile
            Vector3 worldPosition = MyGrid.GridToWorld(tileCoords);

            // Raycast down to find ground
            RaycastHit hit;
            Vector3 rayOrigin = new Vector3(worldPosition.x, 50f, worldPosition.z); // start raycast from high up
            if (Physics.Raycast(rayOrigin, Vector3.down, out hit, 100f))
            {
                worldPosition.y = hit.point.y;
            }
            else
            {
                worldPosition.y = 0f; // fallback
            }

            // Place the tower
            GameObject newTower = Instantiate(towerPrefab, worldPosition, Quaternion.identity);

            // Mark the tile as occupied
            grid.Add(tileCoords, newTower);

            // Subtract the cost from CoinManager
            CoinManager.Instance.SpendCoins(towerCost);

            return true;
        }
    }


}
