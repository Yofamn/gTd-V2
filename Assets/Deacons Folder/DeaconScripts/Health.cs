using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense{
    public class Health : MonoBehaviour
{
     public int currentHealth;
        void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if(currentHealth <= 0)
            {
                if(gameObject.CompareTag("Enemy")){
                    EnemyDeath();
                }
                else if(gameObject.CompareTag("Player")){
                    PlayerDeath();
                }
            }
        }   
        public static void TryDamage(GameObject target, int damage)
        {
            Health targethealth = target.GetComponent<Health>();
            if (target != null) {targethealth.TakeDamage(damage); }
        }
        public void EnemyDeath(){
            Destroy(gameObject);
            // death animation or sound
        }
        public void PlayerDeath(){

            //send to main screen
        }
}

// make a health class for tower defense
}

