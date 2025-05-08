using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace TowerDefense
{
    public class DeaconsCursor : MonoBehaviour
    {
        [Header("Placement Settings")]
        public GameObject towerPrefab;
        [SerializeField] private LayerMask buildableLayer;
        PlayerNumManager playerNumManager;
        private TextMeshProUGUI coinText;

        private MyGrid grid;

        private void Awake()
        {
            grid = FindObjectOfType<MyGrid>();
            if (grid == null)
                Debug.LogError("No MyGrid found in scene!");
        }

        private void Update()
        {
            Vector3Int tileCoords = GetTargetTile();
            transform.position = MyGrid.GridToWorld(tileCoords);

            if (towerPrefab == null) return;

            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                TryPlaceTower(tileCoords);
            }
        }

        private Vector3Int GetTargetTile()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, buildableLayer))
            {
                return MyGrid.WorldToGrid(hit.point + hit.normal * 0.5f);
            }
            return Vector3Int.zero;
        }

        private void TryPlaceTower(Vector3Int tileCoords)
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
                if (Vector3.Angle(hit.normal, Vector3.up) > 5f)
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
                towerPrefab = null; // Clear selection after placing
            }
            else
            {
                Debug.LogWarning("Tower instantiation failed. Coins not spent.");
            }

            towerPrefab = null; // Clear selection after placing
        }
    }
}