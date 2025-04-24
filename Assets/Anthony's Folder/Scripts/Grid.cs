using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class MyGrid : MonoBehaviour
    {
        private Dictionary<Vector3Int, GameObject> gameObjects = new Dictionary<Vector3Int, GameObject>();

        public bool Occupied(Vector3Int tileCoords)
        {
            return gameObjects.ContainsKey(tileCoords);
        }

        public bool Add(Vector3Int tileCoords, GameObject gameObject)
        {
            if (gameObjects.ContainsKey(tileCoords)) return false;

            gameObjects.Add(tileCoords, gameObject);
            return true;
        }

        public void Remove(Vector3Int tileCoords)
        {
            if (!gameObjects.ContainsKey(tileCoords)) return;

            Destroy(gameObjects[tileCoords]);
            gameObjects.Remove(tileCoords);
        }

        public static Vector3Int WorldToGrid(Vector3 worldPosition)
        {
            return new Vector3Int(
                Mathf.RoundToInt(worldPosition.x),
                Mathf.RoundToInt(worldPosition.y),
                Mathf.RoundToInt(worldPosition.z)
            );
        }

        public static Vector3 GridToWorld(Vector3Int gridPosition)
        {
            return gridPosition;
        }

    }
}
