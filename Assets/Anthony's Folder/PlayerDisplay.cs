using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace TowerDefence
{
public class PlayerDisplay : MonoBehaviour
{
    public static PlayerDisplay Instance;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private List<string> hiddenInScenes = new List<string> {"Title"};
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject); // Keep this object across scenes
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(this.gameObject); // Destroy duplicate instances
        }

        if (coinText == null)
        {
            coinText = GetComponent<TextMeshProUGUI>();
        }
        if (healthText == null)
        {
            healthText = GetComponent<TextMeshProUGUI>();
        }
    }

            private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            ReassignCoinText();
            ReassignHealthText();
            // Optional: Immediately update UI with current coin value
            if (PlayerNumManager.Instance != null)
            {
                UpdateCoinText(PlayerNumManager.Instance.GetCoins());
                UpdateHealthText(PlayerNumManager.Instance.getHealth());
            }
        }

        private void ReassignHealthText()
        {
            if (healthText == null)
            {
                healthText = GameObject.FindWithTag("healthText")?.GetComponent<TextMeshProUGUI>();
                if (healthText == null)
                {
                    Debug.LogWarning("healthText: Could not find TextMeshProUGUI with tag 'healthText' in the scene.");
                }
            }
        }
        private void ReassignCoinText()
        {
            if (coinText == null)
            {
                coinText = GameObject.FindWithTag("Coins")?.GetComponent<TextMeshProUGUI>();
                if (coinText == null)
                {
                    Debug.LogWarning("CoinDisplay: Could not find TextMeshProUGUI with tag 'Coins' in the scene.");
                }
            }
        }

    public void UpdateCoinText(int coins)
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins.ToString();
        }
    }
    public void UpdateHealthText(int health)
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString();
        }
    }
}

}
