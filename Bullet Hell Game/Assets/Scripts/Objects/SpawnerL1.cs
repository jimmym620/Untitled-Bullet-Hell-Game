using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerL1 : MonoBehaviour
{
    public Transform InstantiatedParent;
    ObjectPooler objectPooler;
    public GameObject[] enemyList;
    private float timeBetweenWaves;
    public int enemyKillGoal = 5;
    public int enemiesSpawned = 0;
    string[] enemyTypes = {"Taximan", "Bomber"};
    // Start is called before the first frame update
    void Start()
    {
        
        objectPooler = ObjectPooler.Instance;
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

    string chooseEnemy()
    {

        int pick = Random.Range(0, enemyTypes.Length);

        return enemyTypes[pick];

    }   
    IEnumerator spawnEnemy()
    {

        while (enemiesSpawned < enemyKillGoal)
        {
            // GameObject enemy = Instantiate(enemyList[chooseEnemy()], new Vector2(choosePositionX(), choosePositionY()), transform.rotation);
            GameObject enemy = objectPooler.SpawnFromPool(chooseEnemy(), new Vector3(choosePositionX(), choosePositionY(), 0), transform.rotation);
            enemy.transform.SetParent(InstantiatedParent);
            yield return new WaitForSeconds(2f);
            enemiesSpawned++;

        }
    }
}
