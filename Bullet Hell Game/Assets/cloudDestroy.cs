﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudDestroy : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.x < -2) || (transform.position.y > 2)){
            Destroy(gameObject);
        }

    }


}
