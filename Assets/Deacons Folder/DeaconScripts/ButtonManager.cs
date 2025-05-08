using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButtonController : MonoBehaviour
{
    public static TowerButtonController Instance;

    [System.Serializable]
    public class TowerButtonInfo
    {
        public GameObject towerPrefab;
        public Button button;
    }

    public List<TowerButtonInfo> towerButtons;
    public Color selectedColor = Color.green;
    public Color defaultColor = Color.white;

    private Button currentlySelectedButton;

    public GameObject SelectedTowerPrefab { get; set; } // 🔧 Make this settable

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

    private void Start()
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

    public void UpdateSelection(Button newlySelected, GameObject towerPrefab)
    {
        if (currentlySelectedButton != null)
            currentlySelectedButton.GetComponent<Image>().color = defaultColor;

        newlySelected.GetComponent<Image>().color = selectedColor;
        currentlySelectedButton = newlySelected;

        SelectedTowerPrefab = towerPrefab; // ✅ Set selection here
    }

    public void ClearSelection()
    {
        if (currentlySelectedButton != null)
        {
            currentlySelectedButton.GetComponent<Image>().color = defaultColor;
            currentlySelectedButton = null;
        }

        SelectedTowerPrefab = null; // ✅ Clear prefab reference
    }
}
