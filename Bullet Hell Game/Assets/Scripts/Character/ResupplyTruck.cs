using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResupplyTruck : Breakable
{
    ObjectPooler objectPooler;
    public bool enteredScene = false;
    public float speed = 1;

    private Animator SM;

    private float DirX;


    // Start is called before the first frame update
    void Start()
    {
        DirX = 1f;
        objectPooler = ObjectPooler.Instance;
        SM = GetComponent<Animator>();



        // rb.velocity = new Vector2(-DirX, 0);
    }
    public override void OnEnable()
    {
        base.OnEnable();
        enteredScene = false;
        DirX = 1f;
    }



    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (enteredScene == true && other.gameObject.tag == "BorderVertical")
        {
            DirX *= -1f;
        }


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "BorderVertical")
        {
            enteredScene = true;
        }
    }

    public override void Die()
    {
        SM.Rebind();
        SM.Update(0f);
        objectPooler.SpawnFromPool("HealthKit", transform.position, transform.rotation);
        base.Die();
        UI_SoundManager.Instance.playResTruckDeath();
    }

    public float getDirectionX()
    {
        return DirX;
    }

    IEnumerator wait(int sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
