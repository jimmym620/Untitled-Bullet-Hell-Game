using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerL1 : MonoBehaviour
{
    private GameObject player;
    public Transform InstantiatedParent;
    ObjectPooler objectPooler;
    private float timeBetweenWaves;
    public int enemyKillGoal = 5;
    int enemiesSpawned = 0;
    public bool allEnemiesSpawned = false;
    string[] enemyTypes = { "Taximan", "Bomber" };
    private GameObject[] numOfEnemiesRemaining;
    private GameObject[] numOfPlatformsOnScreen;

    private GameObject[] numOfResupTrucksOnScreen;
    private GameObject[] numOfHealthKitsOnScreen;

    public int platformsSpawned = 0;
    public int platformsToSpawn;
    public bool allPassengersCollected = false;

    bool isSpawnResupplyStarted;
    bool isSpawnPlatformStarted;
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        StartCoroutine("spawnEnemy");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Awake()
    {
        // numOfPlatformsOnScreen = GameObject.FindGameObjectsWithTag("Platform");
        // numOfResupTrucksOnScreen = GameObject.FindGameObjectsWithTag("ResupplyTruck");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            // If player loses health, spawn resupply truck
            numOfResupTrucksOnScreen = GameObject.FindGameObjectsWithTag("ResupplyTruck");
            numOfHealthKitsOnScreen = GameObject.FindGameObjectsWithTag("HealthKit");
            if (player.GetComponent<PlayerStats>().health < player.GetComponent<PlayerStats>().maxHealth && numOfResupTrucksOnScreen.Length < 1 && numOfHealthKitsOnScreen.Length < 1)
            {
                if (!isSpawnResupplyStarted)
                {
                    StartCoroutine("spawnResupply");

                }
                // spawnResupply();
            }
        }
        //CHECK enemy amount
        numOfEnemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy");
        //If all enemies are defeated, the wave/level is over;
        if ((numOfEnemiesRemaining.Length == 0) && (allEnemiesSpawned == true) && (allPassengersCollected == true))
        {
            GameControl.instance.waveIsOver = true;
        }
        // CHECK platform amount
        numOfPlatformsOnScreen = GameObject.FindGameObjectsWithTag("Platform");
        if (numOfPlatformsOnScreen.Length < 1 && GameControl.instance.passsengersCollected < platformsToSpawn)
        {   
            if(!isSpawnPlatformStarted){
                StartCoroutine("spawnPlatform");
            }
        }
        // If all passsengers are collected
        if (GameControl.instance.passsengersCollected == platformsToSpawn)
        {
            allPassengersCollected = true;
        }

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
        // return "Taximan";

    }
    IEnumerator spawnEnemy()
    {
        while (enemiesSpawned < enemyKillGoal)
        {
            // GameObject enemy = Instantiate(enemyList[chooseEnemy()], new Vector2(choosePositionX(), choosePositionY()), transform.rotation);
            yield return new WaitForSeconds(5f);
            GameObject enemy = objectPooler.SpawnFromPool(chooseEnemy(), new Vector3(choosePositionX(), choosePositionY(), 0f), transform.rotation);
            enemy.transform.SetParent(InstantiatedParent);
            enemiesSpawned++;
        }
        if (enemiesSpawned == enemyKillGoal)
        {
            StopCoroutine("spawnEnemy");
            allEnemiesSpawned = true;
        }
    }

    void spawnBoss()
    {

    }


    IEnumerator spawnPlatform()
    {
        if (numOfPlatformsOnScreen.Length < 1)
        {
            platformsSpawned++;
            isSpawnPlatformStarted = true;
            yield return new WaitForSeconds(6f);
            GameObject platform_Pass = objectPooler.SpawnFromPool("Platform_Pass", new Vector3(choosePositionX(), choosePositionY(), 0f), transform.rotation);
            platform_Pass.transform.SetParent(InstantiatedParent);
            isSpawnPlatformStarted = false;

        }
    }

    IEnumerator spawnResupply()
    {
        if (numOfHealthKitsOnScreen.Length < 1)
        {
            isSpawnResupplyStarted = true;
            yield return new WaitForSeconds(10f);
            GameObject resupplyTruck = objectPooler.SpawnFromPool("ResupplyTruck", new Vector3(choosePositionX(), choosePositionY(), 0f), transform.rotation);
            resupplyTruck.transform.SetParent(InstantiatedParent);
            isSpawnResupplyStarted = false;
        }

    }


    void newWave()
    {


    }

}
