using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerL1 : MonoBehaviour
{
    public GameObject[] enemyList;
    private float timeBetweenWaves;
    public int enemyKillGoal = 5;
    public int enemiesSpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(spawnEnemy());
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // CHOOSE COORDINATES TO SPAWN ENEMIES
    float choosePositionX()
    {
        float x = Random.Range(4, 7);
        return x;
    }

    float choosePositionY()
    {
        float y = Random.Range((float)1.6, (float)-1.6);
        return y;
    }

    IEnumerator spawnEnemy(){
        
        while(enemiesSpawned < enemyKillGoal)
        {
            Instantiate(enemyList[0], new Vector2(choosePositionX(), choosePositionY()), transform.rotation);
            yield return new WaitForSeconds(3f);
            enemiesSpawned++;

        }
    }
}
