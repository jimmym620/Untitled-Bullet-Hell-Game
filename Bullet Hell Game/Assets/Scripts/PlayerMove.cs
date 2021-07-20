using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 30;
    private float horizontalInput;
    private float verticalInput;

    // public Vector2 speed = new Vector2(50, 50);

    public float yRange = 3;
    public float xRange = 8;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(transform.position.y < -yRange){
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        if(transform.position.y > yRange){
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
        if(transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }


        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * moveSpeed);


        // OLD MOVEMENT
        // // float inputX = Input.GetAxis("Horizontal");
        // // float inputY = Input.GetAxis("Vertical");

        // // Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        // movement *= Time.deltaTime;

        // transform.Translate(movement);

    }
    


}
