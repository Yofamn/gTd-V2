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
    public GameObject[] prefabV2;
    public float spawnRate = 1f;
    public int currentEnemy;
    int waveCounter;
    
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
    IEnumerator SpawnWave2()
    {
        while(spawn)
        {
            if (currentEnemy > prefabV2.Length - 1)
            {
                spawn = false;
                yield break;
            }
            Instantiate(prefabV2[currentEnemy], transform.position, transform.rotation);

            currentEnemy ++;
            yield return new WaitForSeconds(spawnRate);
        }
        
    }

    public void restart()
    {
        currentEnemy = 0;
        spawn = true;
        if(waveCounter == 0)
        {
            StartCoroutine(Spawn());
            waveCounter++;
        }

        else if(waveCounter == 1)
        {
            StartCoroutine(SpawnWave2());
            waveCounter = 0;
        }
        
    }
}
