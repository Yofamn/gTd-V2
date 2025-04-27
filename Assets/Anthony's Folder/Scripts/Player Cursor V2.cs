using System.Collections;
using System.Collections.Generic;
using TowerDefence;
using UnityEngine;

namespace TowerDefense
{
    public class Player2 : MonoBehaviour
    {
        public GameObject towerPrefab;
        public int gold;
        private MyGridV2 grid;
        private Cursor cursor;

        private void Awake()
        {
            grid = FindObjectOfType<MyGridV2>();
            cursor = GetComponent<Cursor>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3Int tileCoords = MyGridV2.WorldToGrid(cursor.transform.position);
                TryPlaceTower(grid, tileCoords);
            }
        }

        public bool TryPlaceTower(MyGridV2 grid, Vector3Int tileCoords)
        {
            if (gold < Tower_SO.GetCost(towerPrefab)) return false;
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

            GameObject newTower = Instantiate(towerPrefab, worldPosition, Quaternion.identity);

            grid.Add(tileCoords, newTower);
            gold -= Tower_SO.GetCost(towerPrefab);
            return true;
        }
    }
}
