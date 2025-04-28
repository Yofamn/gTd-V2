using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class TowerShopUI : MonoBehaviour
    {
        [SerializeField] private GameObject towersMenuPanel;
        [SerializeField] private List<TowerButton> towerButtons;

        private void Start()
        {
            towersMenuPanel.SetActive(false);

            foreach (TowerButton button in towerButtons)
            {
                button.button.onClick.AddListener(() => SelectTower(button.towerPrefab));
            }
        }

        public void OpenTowersMenu()
        {
            towersMenuPanel.SetActive(true);
        }

        public void CloseTowersMenu()
        {
            towersMenuPanel.SetActive(false);
        }

        private void SelectTower(GameObject towerPrefab)
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.towerPrefab = towerPrefab;
            }
            towersMenuPanel.SetActive(false);
        }
    }

    [System.Serializable]
    public class TowerButton
    {
        public Button button;
        public GameObject towerPrefab;
    }
}