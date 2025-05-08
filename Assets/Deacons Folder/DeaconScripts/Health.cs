using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace TowerDefense{
    public class Health : MonoBehaviour
    {
        PlayerNumManager playerNumManager;

        int currentHealth;
        void Awake()
        {
            playerNumManager = FindObjectOfType<PlayerNumManager>();
            
            currentHealth = playerNumManager != null ? playerNumManager.getHealth() : 100;
        }

        

        void TakeDamage(int damage)
            {

                int damageApplied = Mathf.Min(damage, currentHealth);

                if (damageApplied > 0 && playerNumManager != null && gameObject.CompareTag("Enemy"))
                {
                    playerNumManager.AddCoins(damageApplied); // Give coins per damage taken
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

