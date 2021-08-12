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
    int enemiesSpawned = 0;
    public bool allEnemiesSpawned = false;
    string[] enemyTypes = { "Taximan", "Bomber" };
    public GameObject[] numOfEnemiesRemaining;
    public GameObject[] numOfPlatformsOnScreen;

    public int platformsSpawned = 0;
    public int platformsToSpawn;
    public bool allPassengersCollected = false;
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        StartCoroutine(spawnEnemy());
    }

    private void Awake()
    {
        numOfPlatformsOnScreen = GameObject.FindGameObjectsWithTag("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        numOfEnemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy");
        //If all enemies are defeated, the wave/level is over;
        if ((numOfEnemiesRemaining.Length == 0) && (allEnemiesSpawned == true) && (allPassengersCollected == true))
        {
            GameControl.instance.waveIsOver = true;
        }

        numOfPlatformsOnScreen = GameObject.FindGameObjectsWithTag("Platform");
        if (numOfPlatformsOnScreen.Length < 1 && GameControl.instance.passsengersCollected < platformsToSpawn)
        {
            Invoke("spawnPlatform", 3);
            // spawnPlatform();
        }
        if(numOfPlatformsOnScreen.Length > 1)
        {
            numOfPlatformsOnScreen[1].SetActive(false);
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
        if (enemiesSpawned == enemyKillGoal)
        {
            StopCoroutine(spawnEnemy());
            allEnemiesSpawned = true;
        }
    }

    void spawnBoss()
    {

    }

    void spawnPlatform()
    {
        if(numOfPlatformsOnScreen.Length < 1)
        {
        platformsSpawned++;
        GameObject platform_Pass = objectPooler.SpawnFromPool("Platform_Pass", new Vector3(choosePositionX(), choosePositionY(), 1), transform.rotation);
        platform_Pass.transform.SetParent(InstantiatedParent);

        }
    }


}
