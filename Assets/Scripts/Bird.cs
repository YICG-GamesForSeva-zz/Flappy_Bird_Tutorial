using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        // Get the reference to the Animator component
        rb2d = GetComponent<Rigidbody2D>();

        // Get and store the animator reference
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // DO NOT allow the control if the bird has died
        if (isDead == false)
        {
            // Look for input to trigger the "flap"
            if(Input.GetMouseButtonDown(0))
            {
                // Tell the animator about the transition
                anim.SetTrigger("Flap");

                // Then, zero out the birds current y velocity to zero
                rb2d.velocity = Vector2.zero;

                // Now, giving the bird some upward force
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }
    }

    void OnCollisionEnter2D()
    {
        // Zero out the bird's velocity
        rb2d.velocity = Vector2.zero;

        //If the bird collides with something set it to be dead
        isDead = true;

        // Tell the animator about it
        anim.SetTrigger("Die");
    }
}