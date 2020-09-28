using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveColumn : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int upforce;
    private float timeSinceLastSpawned;
    // Use this for initialization
    void Start()
    {
        timeSinceLastSpawned = 0f;
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();

        //Start the object moving.
        rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, upforce);
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= GameControl.instance.speedupTime)
        {
            rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, -(GameControl.instance.scrollSpeed/3f)*upforce);
            timeSinceLastSpawned = 0f;
        }
            // If the game is over, stop scrolling.
            if (GameControl.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
