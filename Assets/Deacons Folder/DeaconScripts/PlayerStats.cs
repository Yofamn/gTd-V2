using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public int maxHealth = 100;
    public float coinIncomeMultiplier = 1f;

    private void Awake() => Instance = this;

    public void IncreaseMaxHealth(int amount) => maxHealth += amount;
    public void MultiplyCoinIncome(float multiplier) => coinIncomeMultiplier *= multiplier;
}

