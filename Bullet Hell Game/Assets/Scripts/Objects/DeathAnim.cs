using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnim : MonoBehaviour
{
    Animator anim;
    public float secondsToWait =.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("play");
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayAnim()
    {
        anim = GetComponent<Animator>();
    }

    IEnumerator play()
    {
        PlayAnim();
        yield return new WaitForSeconds(secondsToWait);
        gameObject.SetActive(false);
        StopCoroutine("play");

    }
}
