using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour, IPooledObject
{
    public float speed = 7f;
    public Rigidbody2D rb;
    public int damage = 40;
    public AudioClip enemyHitmarker;
    private float rightSide = 10;
    public Animator hitmarkerAnimation;


    // Start is called before the first frame update
    public void onObjectSpawn()
    {

        rb.velocity = transform.right * speed;
        hitmarkerAnimation.keepAnimatorControllerStateOnDisable = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > rightSide)
        {
            gameObject.SetActive(false);
        }

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Enemy enemy = hitInfo.GetComponent<Enemy>();
        // if (enemy != null){
        //     enemy.TakeDamage(damage);
        // }

        if (hitInfo.gameObject.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(enemyHitmarker, transform.position);


        }

        // if (hitInfo.gameObject.tag == "BorderVertical" || hitInfo.gameObject.tag == "Platform")
        if (hitInfo.gameObject.tag == "BorderVertical")
        {
            gameObject.SetActive(false);
        }
        // else if(hitInfo.gameObject.tag != "Border"){
        //     AudioSource.PlayClipAtPoint(hitmarker, transform.position);

        // }

        IEntity damageable = hitInfo.GetComponent<IEntity>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
            rb.velocity = Vector2.zero;
            hitmarkerAnimation.SetTrigger("hit");
            // Destroy(gameObject, hitmarkerAnimation.GetCurrentAnimatorStateInfo(0).length /3);

            StartCoroutine(waitAndDisable(0.3f, gameObject));

        }
        // Destroy(gameObject, 7f);

        // Instantiate(impactEffect, transform.position, transform.rotation);

    }

    IEnumerator waitAndDisable(float sec, GameObject obj)
    {

        yield return new WaitForSeconds(sec);
        hitmarkerAnimation.Rebind();
        hitmarkerAnimation.Update(0f);
        obj.SetActive(false);

    }
}
