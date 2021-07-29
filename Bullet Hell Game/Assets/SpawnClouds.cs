using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float cloudYPosition;
    public int maxCloudCount;
    private int cloudCount = 0;

    void FixedUpdate()
    {
        // StartCoroutine(waitRandomSeconds());
        // spawnCloud();
        Invoke("spawnCloud", Random.Range(3, 15));

    }

    float choosePositionX() 
    {
        float x = Random.Range(9, 18);
        return x;
    }

    float choosePositionY() 
    {
        float y = Random.Range(1, (float)1.9);
        return y;
    }



    void spawnCloud()
    {
        while(cloudCount < maxCloudCount){
            Instantiate(cloudPrefab, new Vector2(choosePositionX(), choosePositionY()), transform.rotation);
            cloudCount++;

        }
    }
    
    IEnumerator waitRandomSeconds()
    {
        int wait_time = Random.Range(3, 15);
        yield return new WaitForSeconds(wait_time * Time.deltaTime * 5);

    }
}
