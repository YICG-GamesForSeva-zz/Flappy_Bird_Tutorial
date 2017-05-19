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
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // DO NOT allow control if the bird has died.
        if (isDead == false)
        {
            // Look for input to trigger the "flap"
            if(Input.GetMouseButtonDown(0))
            {
                // Tell the animator about the trigger
                anim.SetTrigger("Flap");

                // Zero out the birds current y velocity 
                rb2d.velocity = Vector2.zero;

                // This gives the bird upward force
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }
    }

    void OnCollisionEnter2D()
    {
        // Zero out the bird's velocity
        rb2d.velocity = Vector2.zero;

        // If the bird collides with something, it is marked to be dead
        isDead = true;

        // Tell the Animator about it
        anim.SetTrigger("Die");
    }
}