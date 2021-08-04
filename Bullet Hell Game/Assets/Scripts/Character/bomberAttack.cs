using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomberAttack : MonoBehaviour
{
    public AudioClip bomberDamageNoise;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            AudioSource.PlayClipAtPoint(bomberDamageNoise, transform.position);
        }

        IEntity damageable = other.GetComponent<IEntity>();
        if(damageable !=null){
            damageable.TakeDamage(60);
            rb.velocity = Vector2.zero;
            Destroy(gameObject, 3f);
        }

    }
}
