using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : BulletBehaviour
{

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {


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
        if (damageable != null && hitInfo.gameObject.tag != "Enemy")
        {
            damageable.TakeDamage(damage);
            rb.velocity = Vector2.zero;
            hitmarkerAnimation.SetTrigger("hit");
            // Destroy(gameObject, hitmarkerAnimation.GetCurrentAnimatorStateInfo(0).length / 3);
            gameObject.SetActive(false);

        }
        

        // Instantiate(impactEffect, transform.position, transform.rotation);

    }



}
