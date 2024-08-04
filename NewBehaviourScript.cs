using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10.0f;
    [SerializeField] float xOffbounds = 7f;
    [SerializeField] float yOffbounds = 5f;

    private float pointZero = 0.0f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlPitchXFactor = -30f;
    [SerializeField] float positionYawFactor = 5f;
    float xThrow, yThrow;

    private void Start()
    {
        Debug.Log("Welcome to my game");
        // Initialization code, if any, goes here
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
        float pitchDueToControlThrowx = xThrow * controlPitchXFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = transform.localPosition.x + pitchDueToControlThrowx;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void PlayerTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * playerSpeed;
        float xPosition = transform.localPosition.x + xOffset;
        float xMovement = Mathf.Clamp(xPosition, -xOffbounds, xOffbounds);

        float yOffset = yThrow * Time.deltaTime * playerSpeed;
        float yPosition = transform.localPosition.y + yOffset;
        float yMovement = Mathf.Clamp(yPosition, -yOffbounds, yOffbounds);

        transform.localPosition = new Vector3(xMovement, yMovement, transform.localPosition.z);
    }
}
