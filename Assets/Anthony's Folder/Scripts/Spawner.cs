using System.Collections;
using TMPro;
using TowerDefence;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static PlayerNumManager Instance;
    
    public bool spawn = false;
    public GameObject[] WaveOne;
    public GameObject[] WaveTwo;
    public GameObject[] WaveThree;
    public GameObject[] WaveFour;
    public GameObject[] WaveFive;
    public GameObject[] WaveSix;
    public GameObject[] WaveSeven;
    public float spawnRate = .5f;
    int currentEnemy;
    int waveCounter;
    GameObject button;
    private TextMeshProUGUI dreadHealthText;

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
            button.SetActive(true);
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
                button.SetActive(true);
                yield break;
            }
            Instantiate(WaveTwo[currentEnemy], transform.position, transform.rotation);

            currentEnemy ++;
            yield return new WaitForSeconds(spawnRate);
        }
        
    }
        IEnumerator SpawnWave3()
    {
        while(spawn)
        {
            if (currentEnemy > WaveThree.Length - 1)
            {
                spawn = false;
                button.SetActive(true);
                yield break;
            }
            Instantiate(WaveThree[currentEnemy], transform.position, transform.rotation);

            currentEnemy ++;
            yield return new WaitForSeconds(spawnRate);
        }
        
    }
        IEnumerator SpawnWave4()
    {
        while(spawn)
        {
            if (currentEnemy > WaveFour.Length - 1)
            {
                spawn = false;
                button.SetActive(true);
                yield break;
            }
            Instantiate(WaveFour[currentEnemy], transform.position, transform.rotation);

            currentEnemy ++;
            yield return new WaitForSeconds(spawnRate);
        }
        
    }
        IEnumerator SpawnWave5()
    {
        while(spawn)
        {
            if (currentEnemy > WaveFive.Length - 1)
            {
                spawn = false;
                button.SetActive(true);
                yield break;
            }
            Instantiate(WaveFive[currentEnemy], transform.position, transform.rotation);

            currentEnemy ++;
            yield return new WaitForSeconds(spawnRate);
        }
        
    }
        IEnumerator SpawnWave6()
    {
        while(spawn)
        {
            if (currentEnemy > WaveSix.Length - 1)
            {
                spawn = false;
                button.SetActive(true);
                yield break;
            }
            Instantiate(WaveSix[currentEnemy], transform.position, transform.rotation);

            currentEnemy ++;
            yield return new WaitForSeconds(spawnRate);
        }
        
    }
        IEnumerator SpawnWave7()
    {
        while(spawn)
        {
            if (currentEnemy > WaveSeven.Length - 1)
            {
                spawn = false;
                //buttonAppear();
                if (waveCounter >= 6)
                {
                    GameObject dreadHealth = GameObject.FindGameObjectWithTag("BossHealth");
                    dreadHealth.SetActive(true);
                    PlayerDisplay.Instance.UpdateDreadHealthText(5000);
                }
                yield break;
            }
            Instantiate(WaveSeven[currentEnemy], transform.position, transform.rotation);

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
            waveCounter++;
        }
        else if(waveCounter == 2)
        {
            StartCoroutine(SpawnWave3());
            waveCounter++;
        }
        else if(waveCounter == 3)
        {
            StartCoroutine(SpawnWave4());
            waveCounter++;
        }
        else if(waveCounter == 4)
        {
            StartCoroutine(SpawnWave5());
            waveCounter++;
        }
        else if(waveCounter == 5)
        {
            StartCoroutine(SpawnWave6());
            waveCounter++;
        }
        else if(waveCounter == 6)
        {
            StartCoroutine(SpawnWave7());
        }
        //Invoke("buttonAppear", 10);
    }

    public void buttonAppear()
    {
        button.SetActive(true);
    }
}
