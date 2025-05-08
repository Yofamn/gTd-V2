using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    
    public class Enemy_Script_1 : MonoBehaviour
    {
        public Path path;
        public int index = 0;
        Health health;
        public Enemy_SO enemy_SO;
        Spawner spawner;
        

        void Start()
        {
            path = FindObjectOfType<Path>();
            StartCoroutine(FollowPath());
        }

        IEnumerator FollowPath()
        {
            Vector3 target;
            while(path.TryGetPoint(index, out target))
            {
                Vector3 start = transform.position;

                float maxDist = Mathf.Min(enemy_SO.Speed * Time.deltaTime, (target - start).magnitude);
                transform.position = Vector3.MoveTowards(start, target, maxDist);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target - start), 0.05f);

                if (Vector3.Distance(transform.position, target) < 0.1f)
                {
                    index++;
                }
                yield return null;
            }
            
            // Uncomment after player/health script is in.
            Debug.Log("Before player dmg");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log(player + " player obj");
            if (player != null)
            {
                // Get this enemy's Health component
                Debug.Log("Insdie player");
                Health enemyHealth = GetComponent<Health>();
                Health playerHealth = GetComponent<Health>();
                if (enemyHealth != null && playerHealth != null)
                {
                    int damage = enemyHealth.getHealth();
                    Health.TryDamage(player, damage);
                    Debug.Log("Damage: "+enemyHealth.getHealth());
                }
            }
            
            Destroy(gameObject);

        }
    }
}