using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;



public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] float playerSpeed = 10.0f;
    [SerializeField] float xOffbounds = 7;
    [SerializeField] float yOffbounds = 5;
   
    private float pointZero = 0.0f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    float xThrow, yThrow;
    private void Start()
    {

        float time = Time.time;
    }

    void Update()
    {
        PlayerTranslation();
        PlayerRotation();

    }

    void PlayerRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;


        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = pointZero;
        float roll = pointZero;



        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
       
    }



    void PlayerTranslation()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * playerSpeed;
        float xPosition = transform.localPosition.x + xOffset;
        float xMovement = Mathf.Clamp(xPosition, -xOffbounds, xOffbounds);

        float yOffset = yThrow * Time.deltaTime * playerSpeed;
        float yPosition = transform.localPosition.y + yOffset;
        float yMovement = Mathf.Clamp(yPosition, -yOffbounds, yOffbounds);

        transform.localPosition = new Vector3(xMovement, yMovement, transform.localPosition.z);
    }
}
