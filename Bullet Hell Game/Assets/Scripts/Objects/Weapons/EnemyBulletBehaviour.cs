using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
    public float speed = 7f;
    public Rigidbody2D rb;
    public int damage = 40;
    public AudioClip enemyHitmarker;
    private float leftSide = 10;
    public Animator hitmarkerAnimation;


    // Start is called before the first frame update
    void Start()
    {

        rb.velocity = transform.right * speed;


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > leftSide)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Enemy enemy = hitInfo.GetComponent<Enemy>();
        // if (enemy != null){
        //     enemy.TakeDamage(damage);
        // }

        if (hitInfo.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(enemyHitmarker, transform.position);

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
            Destroy(gameObject, hitmarkerAnimation.GetCurrentAnimatorStateInfo(0).length / 3);

        }
        Destroy(gameObject, 7f);

        // Instantiate(impactEffect, transform.position, transform.rotation);

    }



}
