using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TowerDefence;

public class PlayerNumManager : MonoBehaviour
    {
        public static PlayerNumManager Instance;

        float multiplier = PlayerStats.Instance?.coinIncomeMultiplier ?? 1f;
        [SerializeField] int coins = 100;
        
        [SerializeField] int health = 100;
        

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
            
            PlayerDisplay.Instance?.UpdateCoinText(coins);
            PlayerDisplay.Instance?.UpdateHealthText(health);
        }

        public void AddCoins(int amount)
        {
            coins += (int)(amount * multiplier);
            PlayerDisplay.Instance?.UpdateCoinText(coins);
        }

        public bool SpendCoins(int amount)
        {
            if (coins >= amount)
            {
                coins -= amount;
                PlayerDisplay.Instance?.UpdateCoinText(coins);
                return true;
            }
            return false;
        }

        public int GetCoins()
        {
            return coins;
        }
        public int getHealth()
        {
            return health;
        }
    }

