using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource gunshotSound;
    public AudioSource reloadSound;
    
    public float fireRate;

    public GameObject FirePoint;

    //reload
    public int maxAmmo = 30;
    private int currentAmmo;
    public float reloadTime = 3f;
    private bool isReloading = false;
    private float nextTimeToFire = 0f;

    // HUD
    public Text ammoDisplay;

    // Start is called before the first frame update
    void Start()
    {
        //beginning reload state
        currentAmmo = maxAmmo;

    }

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = "Gun \n" + currentAmmo.ToString() + "/" + maxAmmo;

        if (isReloading)
            return;
            
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }


        // Mouse button fire
        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0)
        {
            FirePoint.GetComponent<Animator>().SetTrigger("Shooting");
            nextTimeToFire = Time.time + 1 / fireRate;
            gunshotSound.Play();
            Shoot();
        }

        // Press R to reload
        if(Input.GetKey("r")){
            StartCoroutine(Reload());
            return;
        }


    }

    void Shoot()
    {
        currentAmmo--;
        
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       

    }

    IEnumerator Reload(){
        isReloading = true;
        reloadSound.Play();

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
