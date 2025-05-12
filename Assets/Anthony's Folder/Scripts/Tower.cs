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
        
        public Camera mainCamera;
        private void Start()
        {
            animator = GetComponent<Animator>();
            mainCamera = Camera.main;
            follow_Enemy = GetComponent<Follow_Enemy>();
            
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

        
    }
}