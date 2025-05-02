using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TowerDefense;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawn = false;
    public GameObject[] WaveOne;
    public GameObject[] WaveTwo;
    public float spawnRate = .5f;
    int currentEnemy;
    int waveCounter;
    GameObject button;

    void Start()
    {
        button = GameObject.Find("SpawnWave");
    }
    IEnumerator Spawn()
    {
        while(spawn)
        {
            if (currentEnemy > WaveOne.Length - 1)
            {
            spawn = false;
            yield break;
            }
            Instantiate(WaveOne[currentEnemy], transform.position, transform.rotation);

            currentEnemy ++;
            yield return new WaitForSeconds(spawnRate);
        }
        
    }
    IEnumerator SpawnWave2()
    {
        while(spawn)
        {
            if (currentEnemy > WaveTwo.Length - 1)
            {
                spawn = false;
                yield break;
            }
            Instantiate(WaveTwo[currentEnemy], transform.position, transform.rotation);

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
        Invoke("buttonAppear", 8);
    }

    public void buttonAppear()
    {
        button.SetActive(true);
    }
}
