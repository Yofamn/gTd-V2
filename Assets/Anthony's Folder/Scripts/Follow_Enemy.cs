using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Follow_Enemy : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 5f; // Speed of rotation (can be adjusted in the Inspector)

        // Function to rotate the tower towards the enemy
        public void RotateTowardsEnemy(GameObject target)
        {
            if (!target) return;

            // Calculate the direction to the target
            Vector3 direction = target.transform.position - transform.position;
            direction.y = 0; // Ensure the rotation stays on the horizontal plane (assuming the tower rotates around the Y axis)

            // Calculate the target rotation
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            // Smoothly rotate towards the target

            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
