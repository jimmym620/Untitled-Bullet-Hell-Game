using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaximanAttack : Enemy, IPooledObject
{
    ObjectPooler objectPooler_;
    public Transform firePoint;
    private float DirY;
    public Animator firePointAnim;
    public AudioClip[] shootSound;

    // Start is called before the first frame update
    public void onObjectSpawn()
    {
        // StartCoroutine(wait(3));
        DirY = -1f;
        objectPooler_ = ObjectPooler.Instance;
        health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        firePointAnim.keepAnimatorControllerStateOnDisable = true;
    }

    public void Shoot()
    {
        if (gameObject.transform.position.x < 4)
        {
            // wait(3);
            // Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            objectPooler_.SpawnFromPool("Bullet_Red", firePoint.position, firePoint.rotation);
            firePointAnim.SetTrigger("Shoot");
            AudioSource.PlayClipAtPoint(pickShootSound(), transform.position);
        }

    }

    public IEnumerator wait(int waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            // Shoot();

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // // If hit the top border, change direction on y
        // if (other.gameObject.tag == "Border")
        // {
        //     DirY *= -1f;

        // }
    }

    public override void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
            int num = Random.Range(1, 5);
            for (int i = 0; i < num; i++){
                objectPooler_.SpawnFromPool("ElecCoin", gameObject.transform.position, gameObject.transform.rotation);
            }
            
        }
    }
    
    // public Vector2 explodeOutwards(Vector3 instantiatedPosition ){
    //     //take in gameObject.transform.position
    //     float xVal = Random.Range(0.5f, 2f);
    //     float yVal = Random.Range(0.5f, 2f);

    //     Vector2 newPos = new Vector2(instantiatedPosition.x + xVal, instantiatedPosition.y + yVal);


    //     return newPos;
    // }

    public float getDirection()
    {

        return DirY;
    }

    public Vector2 repositionEnemy()
    {
        float y = Random.Range(base.yBoundaries, -base.yBoundaries);
        float x = Random.Range(0, 3);

        return new Vector2(x, y);

    }

    public float repositionEnemyX()
    {

        float x = Random.Range(1, -1);

        return x;
    }

    public float repositionEnemyY()
    {

        float y = Random.Range(1, -1);
        return y;
    }

    private AudioClip pickShootSound()
    {
        int pick = Random.Range(0, shootSound.Length);
        return shootSound[pick];
    }

}

//https://answers.unity.com/questions/1427984/how-to-make-object-move-from-one-random-point-to-a.html
//https://gamedev.stackexchange.com/questions/169488/to-move-an-object-forward-an-exact-distance-and-then-stop