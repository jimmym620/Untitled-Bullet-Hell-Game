﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float moveSpeed = 1f;
    public Transform target; // Drop the player in the inspector of the camera


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }
}
