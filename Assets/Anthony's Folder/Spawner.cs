using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawn = true;
    public GameObject[] prefab;
    public float spawnRate = 1f;
    private int currentEnemy;

    Coroutine spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        spawner = StartCoroutine(Spawn());
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
}
