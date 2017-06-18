using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Use of inheritance is in play here
    where the ScrollingObject class is inheriting
    from the MonoBehaviour class
*/
public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        // Get and store a reference to the Rigidbody2D attached
        // to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();

        // Start moving the object.
        rb2d.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // If the game is over, stop scrolling.
        if (GameController.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}