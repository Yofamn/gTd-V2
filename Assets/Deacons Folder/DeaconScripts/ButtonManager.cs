using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButtonController : MonoBehaviour
{
    [System.Serializable]
    public class TowerButtonInfo
    {
        public GameObject towerPrefab;
        public Button button;
    }

    public List<TowerButtonInfo> towerButtons;

    void Start()
    {
        RefreshButtons();
    }

    public void RefreshButtons()
    {
        foreach (var tb in towerButtons)
        {
            bool isUnlocked = TowerUnlockManager.Instance.IsTowerUnlocked(tb.towerPrefab);
            tb.button.interactable = isUnlocked;
        }
    }
}
