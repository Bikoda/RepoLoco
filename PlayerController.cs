using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalMovement;
    private float verticalMovement;
    private Rigidbody playerRigidbody;
    [SerializeField] float playerSpeed = 10.0f;
    private float pointZero = 0.0f;
    //[SerializeField] float rotationSpeed = 1;
    //private Vector3 startingPosition;
    //[SerializeField] float outOfBoundsX = 7.0f;
    //[SerializeField] float outOfBoundsY = 5.0f;



    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        //startingPosition = transform.position;
        
    }

  
    void Update()
    {

        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        Debug.Log(horizontalMovement);
        Debug.Log(verticalMovement);



        if (horizontalMovement != pointZero) 
         {
             playerRigidbody.AddForce(Vector3.left * playerSpeed);
             
            if (horizontalMovement > pointZero) 
            {
                Debug.Log("YOU PRESSED RIGHT");
                transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
                //transform.Rotate(Vector3.up * playerSpeed * Time.deltaTime);
                /*f (transform.position.x > outOfBoundsX) 
                {
                    transform.position = new Vector3(pointZero, transform.position.y, transform.position.z);
                }*/
            } else
            {
                Debug.Log("YOU PRESSED LEFT");
                transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
               /*if (transform.position.x < -outOfBoundsX)
                {
                    transform.position = new Vector3(pointZero, transform.position.y, transform.position.z);
                }*/
            }

        }

        if (verticalMovement != pointZero)
        {
            playerRigidbody.AddForce(Vector3.left * playerSpeed);

           if (verticalMovement > pointZero)
            {
               Debug.Log("YOU PRESSED UP");
               transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
                /*if (transform.position.y > outOfBoundsY)
                {
                    transform.position = new Vector3(transform.position.y, pointZero, transform.position.z);
                }*/
            }
            else
            {
                Debug.Log("YOU PRESSED DOWN");
                transform.Translate(Vector3.down * playerSpeed * Time.deltaTime);
                /*if (transform.position.y < -outOfBoundsY)
                {
                    transform.position = new Vector3(transform.position.x, pointZero, transform.position.z);
                }*/
           }

        }


    }
}
