using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TowerDefence;
using UnityEngine.SceneManagement;
namespace TowerDefense{
    public class Health : MonoBehaviour
    {
        PlayerNumManager playerNumManager;
        
        [SerializeField]int currentHealth;
        void Awake()
        {
            playerNumManager = FindObjectOfType<PlayerNumManager>();
            
            if(CompareTag("Player"))
            currentHealth = playerNumManager != null ? playerNumManager.getHealth() : 100;
        }

        public void addHealth(int amount){
            currentHealth += amount;
        }
        void TakeDamage(int damage)
            {

                int damageApplied = Mathf.Min(damage, currentHealth);

                if (damageApplied > 0 && playerNumManager != null && gameObject.CompareTag("Enemy"))
                {
                    playerNumManager.AddCoins(damageApplied); // Give coins per damage taken
                }
                currentHealth -= damage;

                    if (gameObject.CompareTag("Player") && PlayerDisplay.Instance != null)
                    {
                        PlayerDisplay.Instance.UpdateHealthText(currentHealth);
                    }

                    if (gameObject.CompareTag("Dreadnought") && PlayerDisplay.Instance != null)
                    {
                        PlayerDisplay.Instance.UpdateDreadHealthText(currentHealth);
                    }
                
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
                if (targethealth != null) 
                {
                    targethealth.TakeDamage(damage); 
                    
                }
                
            }
            public void EnemyDeath(){
                Destroy(gameObject);
                // death animation or sound
            }
            public void PlayerDeath(){
                SceneManager.LoadScene("Death Screen");
                //send to main screen
            }
            public int getHealth()
            {
                return currentHealth;
            }
    }

// make a health class for tower defense
}

