using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elec_coin : MonoBehaviour, IPooledObject
{
    GameObject player_;
    private Rigidbody2D rb;
    [HideInInspector] public float timeStamp;
    [HideInInspector] public Vector2 playerDirection;
    private bool flown;

    public void onObjectSpawn()
    {
        gameObject.SetActive(true);
        flown = false;
        player_ = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("waitAndFly");
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update() {
        if(flown && gameObject.activeSelf == true)
        {
            fly();
        }
    }
    void fly()
    {
        playerDirection = -(transform.position - player_.transform.position).normalized;
        rb.velocity = new Vector2(playerDirection.x, playerDirection.y) * 5f * (Time.time / timeStamp);
    }

    IEnumerator waitAndFly()
    {
        yield return new WaitForSeconds(2f);
        timeStamp = Time.time;
        fly();
        flown = true;
    }



}
