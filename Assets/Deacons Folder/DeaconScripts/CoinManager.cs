using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TowerDefence;

public class CoinManager : MonoBehaviour
    {
        public static CoinManager Instance;


        [SerializeField] int coins = 100;

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
        }

        public void AddCoins(int amount)
        {
            coins += amount;
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
    }

