using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawn = false;
    public GameObject[] prefab;
    public float spawnRate = 1f;
    public int currentEnemy;


    Coroutine spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        if(spawn)
        {
            spawner = StartCoroutine(Spawn());
        }
    }

    void Update()
    {
        if(currentEnemy > prefab.Length-1)
        {
            StopCoroutine(spawner);
        }
    }
    // Update is called once per frame
    IEnumerator Spawn()
    {
        while(spawn)
        {
            Instantiate(prefab[currentEnemy], transform.position, transform.rotation);

            currentEnemy ++;
            yield return new WaitForSeconds(spawnRate);
        }
        
    }
    public int getEnemyCount()
    {
        return currentEnemy;
    }
    public void changeEnemyCount(int yes)
    {
        currentEnemy = yes;
    }
    public void restart()
    {
        spawn = true;
    }
}
