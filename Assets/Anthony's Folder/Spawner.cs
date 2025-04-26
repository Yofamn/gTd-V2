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
    
    IEnumerator Spawn()
    {
        while(spawn)
        {
            if (currentEnemy > prefab.Length - 1)
            {
            spawn = false;
            yield break;
            }
            Instantiate(prefab[currentEnemy], transform.position, transform.rotation);

            currentEnemy ++;
            yield return new WaitForSeconds(spawnRate);
        }
        
    }

    public void restart()
    {
        currentEnemy = 0;
        spawn = true;
        StartCoroutine(Spawn());
    }
}
