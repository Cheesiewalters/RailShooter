using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In meters/s")][SerializeField]
    private float playervelocity = 100f;
    [Tooltip("In m")] [SerializeField] 
    float xRange = 10f;
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
        transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
    }

    private void processTranslation()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = horizontalThrow * playervelocity * Time.deltaTime;
        float yOffset = verticalThrow * playervelocity * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawyPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawyPos, -xRange, xRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
