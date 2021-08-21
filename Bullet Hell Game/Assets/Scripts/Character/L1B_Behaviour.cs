using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1B_Behaviour : Enemy
{
    ObjectPooler objectPooler_;
    public Transform firePoint;
    public HealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar.setMaxHealth(base.health);
    }   

    
    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        healthBar.setHealth(base.health);
    }

    public void Shoot()
    {
        if (gameObject.transform.position.x < 3)
        {
            wait(3);
            // Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            objectPooler_.SpawnFromPool("Bullet_Red", firePoint.position, firePoint.rotation);

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
}
