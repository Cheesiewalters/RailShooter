using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In meters/s")][SerializeField] private float playervelocity = 100f;
    [Tooltip("In m")] [SerializeField] float xRange = 10f;

    [SerializeField] private float posPitchFactor = -5f;
    [SerializeField] private float controlPitchFactor = -5f;


     float xThrow;
     float yThrow;
    void Start()
    {
       
    }

    void Update()
    {
        processTranslation();
        processRotation();
    }

    private void processRotation()
    {
        float pitch = transform.localRotation.y * posPitchFactor + yThrow  *controlPitchFactor;
        float yaw = 0f;
        float roll = 0f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void processTranslation()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * playervelocity * Time.deltaTime;
        float yOffset = yThrow * playervelocity * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawyPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawyPos, -xRange, xRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
