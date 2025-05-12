using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using JetBrains.Annotations;

namespace TowerDefense
{
    public class DeaconsCursor : MonoBehaviour
    {
        [Header("Placement Settings")]
        private LayerMask buildableLayer;

        private MyGrid grid;

        private void Awake()
        {
            grid = FindObjectOfType<MyGrid>();
            if (grid == null)
                Debug.LogError("No MyGrid found in scene!");
            buildableLayer = 1<< LayerMask.NameToLayer("BuildSurface");
        }


        public GameObject selectedTower;
        private void Update()
        {
            selectedTower = TowerButtonController.Instance?.SelectedTowerPrefab;
            
            if (selectedTower == null) return;

            Vector3Int tileCoords = GetTargetTile();
            transform.position = MyGrid.GridToWorld(tileCoords);


            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                TryPlaceTower(tileCoords, selectedTower);
            }
        }

        private Vector3Int GetTargetTile()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, buildableLayer))
            {
                if (hit.collider != null && hit.collider.CompareTag("Tower")) 
                {
                    return Vector3Int.zero; // Don't place a tower on another tower
                }
                return MyGrid.WorldToGrid(hit.point + hit.normal * 0.5f);
            }
            return Vector3Int.zero;
        }

        private void TryPlaceTower(Vector3Int tileCoords, GameObject towerPrefab)
        {
            int towerCost = Tower_SO.GetCost(towerPrefab);

            if (PlayerNumManager.Instance.GetCoins() < towerCost)
            {
                Debug.Log("Not enough gold to place tower!");
                return;
            }

            if (grid.Occupied(tileCoords))
            {
                Debug.Log("Tile already occupied!");
                return;
            }

            Vector3 worldPosition = MyGrid.GridToWorld(tileCoords);

            // Adjust Y with raycast
            Vector3 rayOrigin = new Vector3(worldPosition.x, 50f, worldPosition.z);
            if (Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, 100f, buildableLayer))
            {
                if (Vector3.Angle(hit.normal, Vector3.up) > 1f)
                {
                    Debug.Log("Surface too steep to build.");
                    return;
                }

                worldPosition.y = hit.point.y;
            }

            GameObject newTower = Instantiate(towerPrefab, worldPosition, Quaternion.identity);

            if (newTower != null)
            {
                grid.Add(tileCoords, newTower);
                PlayerNumManager.Instance.SpendCoins(towerCost);
                TowerButtonController.Instance.ClearSelection(); // Unselect after placing
            }
            else
            {
                Debug.LogWarning("Tower instantiation failed. Coins not spent.");
            }
        }
    }
}
