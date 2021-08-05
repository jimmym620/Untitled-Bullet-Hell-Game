using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaximanAttack : Enemy
{
    ObjectPooler objectPooler;
    public Transform firePoint;
    private float DirY;
    private bool enteredScene;
    

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(wait(3));
        DirY = -1f;
        objectPooler = ObjectPooler.Instance;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {
        if (gameObject.transform.position.x < 3){
            wait(3);
            // Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            objectPooler.SpawnFromPool("Bullet_Red", firePoint.position, firePoint.rotation);

        }
        
    }

    public IEnumerator wait(int waitTime){
        while(true){
            yield return new WaitForSeconds(waitTime);
        // Shoot();

        }
    }

    //Patrolling up and down
    // void FixedUpdate()
    // {
    //     rb.velocity = new Vector2(rb.velocity.x, DirY * moveSpeed);
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Border")
        {
            DirY *= -1f;

        }

        if (other.gameObject.tag == "BorderVertical")
        {
            enteredScene = true;
        }

        if ((other.gameObject.tag == "BorderVertical") && enteredScene == true){

            rb.velocity = Vector2.zero;
        }

}

    public float getDirection(){

        return DirY;
    }

    public Vector2 repositionEnemy(){
        float y = Random.Range(base.yBoundaries, -base.yBoundaries);
        float x = Random.Range(2, 3);

        return new Vector2(x, y);

    }

    public float repositionEnemyX(){

        float x = Random.Range(1, -1);

        return x;
    }

    public float repositionEnemyY(){

        float y = Random.Range(1, -1);
        return y;
    }


}

//https://answers.unity.com/questions/1427984/how-to-make-object-move-from-one-random-point-to-a.html
//https://gamedev.stackexchange.com/questions/169488/to-move-an-object-forward-an-exact-distance-and-then-stop