using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TowerDefense
{
    public class Path : MonoBehaviour
    {
        [SerializeField]private List<Vector3> points = new List<Vector3>();

        void Awake()
        {
            CollectPoints();
        }
        private void CollectPoints()
        {
            points = new List<Vector3>();
            MyGrid grid = FindObjectOfType<MyGrid>();

            for(int i = 0; i< transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                Vector3 point = child.transform.position;

                points.Add(point);
                grid.Add(MyGrid.WorldToGrid(point), child);
                child.SetActive(false);
            }
            
        }

        public bool TryGetPoint(int index, out Vector3 point)
        {
            point = Vector3.zero;
            if(index < 0 || index >= points.Count) return false;

            point = points[index];
            return true;
        }
    }
}
