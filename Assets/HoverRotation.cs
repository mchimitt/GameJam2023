using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverRotation : MonoBehaviour
{
    public float hoverHeight = 0.001f; // Adjusted hover height
    public float hoverSpeed = 1f;    // Adjusted hover speed
    public float rotationSpeed = 30f; // Adjusted rotation speed

    private void Update()
    {
        // Hover up and down
        float hoverOffset = Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
        transform.position = new Vector3(transform.position.x, transform.position.y + hoverOffset, transform.position.z);

        // Rotate
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
