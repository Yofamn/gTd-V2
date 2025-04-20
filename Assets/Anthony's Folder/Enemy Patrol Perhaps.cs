using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

namespace TowerDefence
{
    public class EnemyPatrolPerhaps : MonoBehaviour
    {
        NavMeshAgent agent;
        public Transform[] waypoints;
        int waypointIndex;
        Vector3 target;
        Turret turret;
        float range = 5f;
        public Transform player;

        void Start()
        {
            turret = GetComponent<Turret>();
            agent = GetComponent<NavMeshAgent>();
            UpdateDestination();
        }
        // Update is called once per frame
        private void Update()
        {

            float distance = Vector3.Distance(transform.position, player.position);

        
            //turret.Bang();
            /*if(turret.inRange())
            {
                    Vector3 temp = gameObject.transform.position;
                    agent.SetDestination(temp);
                    turret.Bang();
            }
            else if(Vector3.Distance(transform.position, target) < 1)
            {
                IterateWaypointIndex();
                UpdateDestination();
            }*/
            if(Vector3.Distance(transform.position, target) < 1)
            {
                if (distance <= range)
                {
                    agent.isStopped = true;

                    turret.Bang();
                }
                else
                {
                    // Player is out of range, resume movement and set a destination
                    agent.isStopped = false;
                    IterateWaypointIndex();
                    UpdateDestination(); 
                    
                }
                
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

