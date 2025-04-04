using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    
    public class Enemy_Script_1 : MonoBehaviour
    {
        public Path path;
        public int index = 0;
        
        public Enemy_SO enemy_SO;
        
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

                if(transform.position == target) index++;
                yield return null;
            }
            
            // Uncomment after player/health script is in.
            
            //Player player = FindObjectOfType<Player>();
            //Health.TryDamage(player.gameObject,damage);
            //Destroy(gameObject);

            //Delete Later
            Destroy(gameObject);
        }
    }
}