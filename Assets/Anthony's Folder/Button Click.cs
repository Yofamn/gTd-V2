using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public Spawner spawn;

    public void spawnEnemies()
    {
        spawn.restart();
    }
}
