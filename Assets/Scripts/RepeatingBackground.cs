using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;  // Storing a reference to the collider already attached to the Ground
    private float groundHorizontalLength;  // A floating point number to store the x-axis length of the ground game object

    // Awake is called before start.
    private void Awake()
    {
        // Store the reference to the ground collider
        groundCollider = GetComponent<BoxCollider2D>();

        // Store the size of the collider along the x-axis
        groundHorizontalLength = groundCollider.size.x;
    }

    private void Update()
    {
        // Check if the difference between the camera position and the
        // actual ground is big enough to reposition the ground along the 
        // x-axis
        if (transform.position.x < -groundHorizontalLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

        transform.position = (Vector2)transform.position + groundOffSet;
    }
}