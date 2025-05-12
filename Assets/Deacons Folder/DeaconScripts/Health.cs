using TowerDefence;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    PlayerNumManager playerNumManager;

    [SerializeField] int currentHealth;
    void Awake()
    {
        playerNumManager = FindObjectOfType<PlayerNumManager>();
        if (CompareTag("Player"))
        {
            currentHealth = playerNumManager != null ? playerNumManager.getHealth() : 100;
        }
        Debug.Log("Enemy HP: " + currentHealth);
    }

    public void addHealth(int amount)
    {
        currentHealth += amount;

        if (gameObject.CompareTag("Player") && PlayerDisplay.Instance != null)
        {
            PlayerDisplay.Instance.UpdateHealthText(currentHealth);
        }
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

        if (currentHealth <= 0)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                EnemyDeath();
            }
            else if (gameObject.CompareTag("Player"))
            {
                PlayerDeath();
            }
        }
    }

    public static void TryDamage(GameObject target, int damage)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }
    }

    public void EnemyDeath()
    {
        FinalBoss finalBossMarker = gameObject.GetComponent<FinalBoss>();
        if (finalBossMarker != null && finalBossMarker.isFinalBoss)
        {
            Debug.Log("Final Boss defeated! Loading the next scene.");
            LoadNextScene();
        }

        Destroy(gameObject); 
    }


    public void PlayerDeath()
    {
        SceneManager.LoadScene("Death Screen");
    }

    
    void LoadNextScene()
    {
        
        SceneManager.LoadScene("Final Boss");
    }

    public int getHealth()
    {
        return currentHealth;
    }
}
