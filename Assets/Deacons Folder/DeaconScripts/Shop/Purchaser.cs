using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

public interface IPurchaser{
    float GetCurrentFunds();
    bool SpendFunds(int amount);
}

public class Purchaser : MonoBehaviour, IPurchaser
{
    [SerializeField] int CurrentFunds;

    public float GetCurrentFunds()
    {
        return CoinManager.Instance.GetCoins();
    }

    public bool SpendFunds(int amount)
    {
        return CoinManager.Instance.SpendCoins(amount);
    }
    public void AddFunds(int amount){
        CoinManager.Instance.AddCoins(amount);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
