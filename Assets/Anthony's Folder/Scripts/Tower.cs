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
        GameObject enemeyTarget;
        Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public GameObject GetEnemyTarget()
        {
            return enemeyTarget;
        }

        public void DamageTarget()
        {
            if(!enemeyTarget)
            return;
            
            Health.TryDamage(enemeyTarget, towerType.damage);
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
                removeDestroyedEnemies();
                if(enemiesInRange.Count> 0)
                {
                    enemeyTarget = enemiesInRange[0];
                    animator.SetTrigger("Fire");
                }
                
                yield return new WaitForSeconds(towerType.fireRate);
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
    }
}