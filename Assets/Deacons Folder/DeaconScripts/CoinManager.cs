using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

    public class CoinManager : MonoBehaviour
    {
        public static CoinManager Instance;
        [SerializeField] private TextMeshProUGUI coinText;

        [SerializeField] int coins = 0;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            updateCoinText();
        }

        public void AddCoins(int amount)
        {
            coins += amount;
            updateCoinText();
        }

        public bool SpendCoins(int amount)
        {
            if (coins >= amount)
            {
                coins -= amount;
                updateCoinText();
                return true;
            }
            return false;
        }

        public int GetCoins()
        {
            return coins;
        }

        public void updateCoinText()
        {
            
            coinText.text = "Coins: " + GetCoins().ToString();
        }


    }

