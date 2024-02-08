using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouSpinMeRightRound : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed; // Adjust this value to change the speed of rotation
    public float minRotation = 100f;
    public float maxRotation = 500f;

    void Update()
    {
        rotationSpeed = Random.Range(minRotation, maxRotation);
        // Rotate the sprite continuously around the Z-axis
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

}
