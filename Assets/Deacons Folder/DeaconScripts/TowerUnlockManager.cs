using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TowerUnlockManager : MonoBehaviour
{
    public static TowerUnlockManager Instance;
    private HashSet<GameObject> unlockedTowers = new HashSet<GameObject>();

    private void Awake() => Instance = this;

    public void UnlockTower(GameObject tower) => unlockedTowers.Add(tower);

    public bool IsTowerUnlocked(GameObject tower) => unlockedTowers.Contains(tower);

    public List<GameObject> GetUnlockedTowers() => unlockedTowers.ToList();
}
