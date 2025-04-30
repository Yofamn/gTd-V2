using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class CoinManager : MonoBehaviour
    {
        public static CoinManager Instance;

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
        }

        public void AddCoins(int amount)
        {
            coins += amount;
        }

        public bool SpendCoins(int amount)
        {
            if (coins >= amount)
            {
                coins -= amount;
                return true;
            }
            return false;
        }

        public int GetCoins()
        {
            return coins;
        }
    }

