using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float cloudYPosition;
    public int maxCloudCount;

    void FixedUpdate()
    {
        // StartCoroutine(waitRandomSeconds());
        // spawnCloud();
        if (GameObject.FindGameObjectsWithTag("Cloud").Length < maxCloudCount)
        {
            spawnCloud();

        }


    }

    float choosePositionX() 
    {
        float x = Random.Range(9, 18);
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
    
        Instantiate(cloudPrefab, new Vector3(choosePositionX(), choosePositionY(), choosePositionZ()), transform.rotation);
        

    }
    
    IEnumerator waitRandomSeconds()
    {
        int wait_time = Random.Range(3, 15);
        yield return new WaitForSeconds(wait_time * Time.deltaTime * 5);

    }
}
