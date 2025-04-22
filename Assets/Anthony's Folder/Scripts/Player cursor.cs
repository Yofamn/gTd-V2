using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Player : MonoBehaviour
    {
        public GameObject towerPrefab;
        public int gold;
        MyGrid grid;
        Cursor cursor;

        private void Awake()
        {
            grid = FindObjectOfType<MyGrid>();
            cursor = GetComponent<Cursor>();
        }
        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                TryPlaceTower(grid, MyGrid.WorldToGrid(cursor.transform.position));
            }
        }

        public bool TryPlaceTower(MyGrid grid, Vector3Int tileCoords)
        {
            if(gold < Tower_SO.GetCost(towerPrefab)) return false;
            if (grid.Occupied(tileCoords)) return false;

            GameObject newTower = Instantiate(towerPrefab, tileCoords, Quaternion.identity);
            grid.Add(tileCoords, newTower);
            gold -=Tower_SO.GetCost(towerPrefab);
            return true;
        }  
    }
}
