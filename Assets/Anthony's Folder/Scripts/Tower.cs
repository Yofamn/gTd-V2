using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [RequireComponent(typeof(Animator))]
    public class Tower : MonoBehaviour
    {
        [SerializeField] private List<GameObject> enemiesInRange = new List<GameObject>();
        public Tower_SO towerType;
        private bool firing = false;
        GameObject enemyTarget;
        Animator animator;
        Follow_Enemy follow_Enemy;
        [SerializeField] GameObject range;
        private void Start()
        {
            animator = GetComponent<Animator>();
            follow_Enemy = GetComponent<Follow_Enemy>();
            range.SetActive(false);
        }
        void Update()
        {
            
        }
        public GameObject GetEnemyTarget()
        {
            return enemyTarget;
        }

        public void DamageTarget()
        {
            if(!enemyTarget)
            return;
            
            Health.TryDamage(enemyTarget, towerType.damage);
        }

        private void removeDestroyedEnemies()
        {
            int i = 0;
            while(i< enemiesInRange.Count)
            {
                if (enemiesInRange[i])
                {
                    i++;
                }
                else
                enemiesInRange.RemoveAt(i);
            }
        }

        IEnumerator DamageEnemyTarget()
        {
            firing = true;

            while(enemiesInRange.Count > 0)
            {
                if(!enemiesInRange[0]) enemiesInRange.RemoveAt(0);
                else 
                {  
                    enemyTarget = enemiesInRange[0];
                    follow_Enemy.RotateTowardsEnemy(enemyTarget);
                    Health.TryDamage(enemiesInRange[0], towerType.damage);
                    
                }

                yield return new WaitForSeconds(towerType.fireRate);

                int x = 0;
                while(x < enemiesInRange.Count)
                {
                    if(!enemiesInRange[0]) enemiesInRange.RemoveAt(0);
                    else x++;
                }

            }

            firing = false;
        }

        void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Enemy")) enemiesInRange.Add(other.gameObject);

            if(!firing) StartCoroutine(DamageEnemyTarget());
        }

        void OnTriggerExit(Collider other)
        {
            enemiesInRange.Remove(other.gameObject);
        }
        void OMouseEnter()
        {
            range.SetActive(true);
        }
        void OnMouseExit()
        {
            range.SetActive(false);
        }
        
        // https://www.google.com/search?q=unity+how+to+get+gameobject+of+a+child+in+parent+prefab&sca_esv=b703f1cd0674f892&rlz=1C1GCHA_enUS1124US1124&ei=-1ciaK3FMv3dwN4PmLTS-AE&oq=unity+how+to+get+gameobject+of+a+child+in+parent&gs_lp=Egxnd3Mtd2l6LXNlcnAiMHVuaXR5IGhvdyB0byBnZXQgZ2FtZW9iamVjdCBvZiBhIGNoaWxkIGluIHBhcmVudCoCCAAyBRAhGKABMgUQIRigATIFECEYoAEyBRAhGKABMgUQIRigATIFECEYnwVIzUtQkwlYkD9wBngBkAEBmAGeAaABwxKqAQQyNy4zuAEByAEA-AEBmAIhoALfEcICChAAGLADGNYEGEfCAgYQABgWGB7CAgsQABiABBiGAxiKBcICBRAAGO8FwgIFEAAYgATCAgUQIRirApgDAIgGAZAGB5IHBDMxLjKgB-OtAbIHBDI1LjK4B80R&sclient=gws-wiz-serp
    }
}