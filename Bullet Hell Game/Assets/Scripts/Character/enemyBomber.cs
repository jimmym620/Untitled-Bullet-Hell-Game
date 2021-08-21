using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBomber : Enemy, IPooledObject
{
    ObjectPooler objectPooler_;
    public float followSpeed;
    private Transform target;
    public float damage;
    public AudioSource proximitySound;
    private float proximity = 4;
    private bool isDead = false;
    int soundCount;
    int maxSoundCount = 52;
    private Animator anim;
   

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    public void onObjectSpawn()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        objectPooler_ = ObjectPooler.Instance;
    }
    private void OnEnable()
    {
        anim.SetBool("isFollowing", true);
    }
    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector2.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
        float distanceToPlayer = Vector2.Distance(target.position, transform.position);
        if ((distanceToPlayer < proximity) && soundCount < maxSoundCount)
        {
            if (proximitySound.isPlaying && isDead)
            {
                proximitySound.Stop();
            }
            if (!proximitySound.isPlaying)
            {
                proximitySound.Play();
                soundCount++;
            }
        }

    }

    public override void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
            objectPooler_.SpawnFromPool("ElecCoin", gameObject.transform.position, gameObject.transform.rotation);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        IEntity damageable = other.GetComponent<IEntity>();
        if (damageable != null && other.gameObject.tag == "Player")
        {
            damageable.TakeDamage(damage);
            isDead = true;
            base.Die();

            gameObject.SetActive(false);
        }

    }

}
