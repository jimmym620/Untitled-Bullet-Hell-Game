using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
    ObjectPooler objectPooler;
    public GameObject[] cloudPrefab;
    public float cloudYPosition;
    public int maxCloudCount;
    public Transform CloudObject;

    void FixedUpdate()
    {
        // StartCoroutine(waitRandomSeconds());
        // spawnCloud();
        if (GameObject.FindGameObjectsWithTag("Cloud").Length < maxCloudCount)
        {
            spawnCloud();

        }

    }

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    float choosePositionX()
    {
        float x = Random.Range(6, 25);
        return x;
    }

    float choosePositionY()
    {
        float y = Random.Range((float)0.6, (float)1.9);
        return y;
    }

    float choosePositionZ()
    {
        float z = Random.Range(0, 10);
        return z;
    }


    void spawnCloud()
    {

        // GameObject cloud = Instantiate(cloudPrefab[0], new Vector3(choosePositionX(), choosePositionY(), choosePositionZ()), transform.rotation);
        GameObject cloud = objectPooler.SpawnFromPool("Cloud", new Vector3(choosePositionX(), choosePositionY(), choosePositionZ()), transform.rotation);
        cloud.transform.SetParent(CloudObject);

    }

    IEnumerator waitRandomSeconds()
    {
        int wait_time = Random.Range(3, 15);
        yield return new WaitForSeconds(wait_time * Time.deltaTime * 5);

    }
}
