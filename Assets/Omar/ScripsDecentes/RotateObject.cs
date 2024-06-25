using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 180f;

    void Update()
    {
        float rotationThisFrame = rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotationThisFrame);
    }
}

