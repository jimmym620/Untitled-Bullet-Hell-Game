using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10;
    public float horizontalInput;
    public float verticalInput;

    // public Vector2 speed = new Vector2(50, 50);

    [SerializeField] public float yRange = 1.4f;
    [SerializeField] public float yRangeBottom = 18f;
    [SerializeField] public float xRange = 1;
    [SerializeField] public float xRangeRight = 3;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(transform.position.y < -yRangeBottom){
            transform.position = new Vector3(transform.position.x, -yRangeBottom, transform.position.z);
        }
        if(transform.position.y > yRange){
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
        if(transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRangeRight)
        {
            transform.position = new Vector3(xRangeRight, transform.position.y, transform.position.z);
        }


        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);

        verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * moveSpeed);


        // OLD MOVEMENT
        // // float inputX = Input.GetAxis("Horizontal");
        // // float inputY = Input.GetAxis("Vertical");

        // // Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        // movement *= Time.deltaTime;

        // transform.Translate(movement);

    }
    


}
