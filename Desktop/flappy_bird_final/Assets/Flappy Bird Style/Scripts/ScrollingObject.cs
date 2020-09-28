using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour 
{
	private Rigidbody2D rb2d;
    private float timeSinceLastSpawned;
    // Use this for initialization
    void Start () 
	{
        timeSinceLastSpawned = 0f;
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();

		//Start the object moving.
		rb2d.velocity = new Vector2 (GameControl.instance.scrollSpeed, 0);
	}

	void Update()
	{

        timeSinceLastSpawned += Time.deltaTime;
        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= GameControl.instance.speedupTime)
        {
            //Debug.Log(GameControl.instance.scrollSpeed.ToString());
            rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
            timeSinceLastSpawned = 0f;
        }
            // If the game is over, stop scrolling.
        if (GameControl.instance.gameOver == true)
		{
			rb2d.velocity = Vector2.zero;
		}
	}
}
