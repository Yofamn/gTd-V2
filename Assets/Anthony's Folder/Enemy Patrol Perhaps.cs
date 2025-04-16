using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TowerDefence
{
    public class EnemyPatrolPerhaps : MonoBehaviour
    {
        NavMeshAgent agent;
        public Transform[] waypoints;
        int waypointIndex;
        Vector3 target;
        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            UpdateDestination();
        }

        // Update is called once per frame
        void Update()
        {
            if(Vector3.Distance(transform.position, target) < 1)
            {
                IterateWaypointIndex();
                UpdateDestination();
            }
        }
        void UpdateDestination()
        {
            target = waypoints[waypointIndex].position;
            agent.SetDestination(target);
        }

        void IterateWaypointIndex()
        {
            waypointIndex++;
            Vector3 start = transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target - start), 0.05f);
            if(waypointIndex == waypoints.Length)
            {
                waypointIndex = 0;
            }
        }

    }
}

