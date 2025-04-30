using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense{
    public class Health : MonoBehaviour
    {
        CoinManager coinManager;
        
        void Awake()
        {
            coinManager = FindObjectOfType<CoinManager>();
        }

        public int currentHealth;
        int totalHealth;

        void Start()
        {
            totalHealth  = currentHealth;
        }

        void TakeDamage(int damage)
            {

                int damageApplied = Mathf.Min(damage, currentHealth);

                if (damageApplied > 0 && coinManager != null && gameObject.CompareTag("Enemy"))
                {
                    coinManager.AddCoins(damageApplied); // Give coins per damage taken
                }
                currentHealth -= damage;

                if(currentHealth <= 0)
                {
                    if(gameObject.CompareTag("Enemy"))
                    {
                        EnemyDeath();
                    }
                    else if(gameObject.CompareTag("Player"))
                    {
                        PlayerDeath();
                    }
                }
                
            }   
            public static void TryDamage(GameObject target, int damage)
            {
                Health targethealth = target.GetComponent<Health>();
                if (targethealth != null) {targethealth.TakeDamage(damage); }
            }
            public void EnemyDeath(){

                Destroy(gameObject);
                // death animation or sound
            }
            public void PlayerDeath(){

                //send to main screen
            }
            public int getHealth()
            {
                return currentHealth;
            }
    }

// make a health class for tower defense
}

