using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense{
    public class CoinManager : MonoBehaviour
    {
        public static CoinManager Instance;

        public int coins = 0;

        private void Awake()
        {
            // Singleton logic
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // Keep this object alive across scenes
            }
            else
            {
                Destroy(gameObject); // Prevent duplicates
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
    }

}
