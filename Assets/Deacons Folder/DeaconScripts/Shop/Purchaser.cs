using System.Collections;
using System.Collections.Generic;
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
        return CurrentFunds;
    }

    public bool SpendFunds(int amount)
    {
        if(CurrentFunds >= amount){ CurrentFunds -= amount; return true;}
        return false;
    }
    public void AddFunds(int amount){
        CurrentFunds += amount;
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
