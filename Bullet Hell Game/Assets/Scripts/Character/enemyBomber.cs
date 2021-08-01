using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBomber : Enemy
{
    public float followSpeed;
    private Transform target;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        IEntity damageable = other.GetComponent<IEntity>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
            base.Die();
            Destroy(gameObject, 3f);
        }

    }
}
