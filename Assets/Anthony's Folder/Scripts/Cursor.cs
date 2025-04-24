using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Cursor : MonoBehaviour
    {
        Vector3Int GetTragetTile()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                Vector3Int targetTile;
                targetTile = MyGrid.WorldToGrid(hit.point + hit.normal * 0.5f);
                return targetTile;
            }

            return Vector3Int.one;
        }
        // Update is called once per frame
        void Update()
        {
            transform.position = GetTragetTile();
        }
    }
}