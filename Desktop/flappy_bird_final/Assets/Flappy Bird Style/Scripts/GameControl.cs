using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;


public class GameControl : MonoBehaviour 
{
    public float speedupTime;
    public bool ishard;
	public static GameControl instance;			//A reference to our game control script so we can access it statically.
	public Text scoreText;                      //A reference to the UI text component that displays the player's score.
    public Text highestText;
    public GameObject gameOvertext;				//A reference to the object that displays the text which appears when the player dies.
    public Text movementSpeedText;


	private int score = 0;                      //The player's score.
    private int highest = 0;
    public bool gameOver = false;				//Is the game over?
	public float scrollSpeed = -1.5f;
    private float speed = 1;
    private float timeSinceLastSpawned;

    void Awake()
	{
        //timeSinceLastSpawned = 0f;
        //If we don't currently have a game control...
        //Load();
        if (instance == null)
        {
            //...set this one to be it...
            instance = this;
        }
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
	}

    void Update()
    {
        //If the game is over and the player has pressed some input...
        /*if (gameOver && Input.GetKeyDown(KeyCode.C))
        {
            //Save0();
            highestText.text = "Highest: " + highest.ToString();
        }*/
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            //...reload the current scene.
            //Save();
            //SceneManager.GetActiveScene().buildIndex
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //timeSinceLastSpawned += Time.deltaTime;
        /*if (ishard && GameControl.instance.gameOver == false && timeSinceLastSpawned >= speedupTime)
        {
            GameControl.instance.scrollSpeed -= 0.2f;
            timeSinceLastSpawned = 0f;
            speed += 0.2f;
            movementSpeedText.text = "Game Speed:"+(speed).ToString();
        }*/
    }

	public void BirdScored()
	{
		//The bird can't score if the game is over.
		if (gameOver)	
			return;
		//If the game is not over, increase the score...
		score++;
		//...and adjust the score text.
		scoreText.text = "Score: " + score.ToString();
        if (score > highest)
        {
            highest = score;
            highestText.text = "Highest: " + highest.ToString();
        }
    }

   

	public void BirdDied()
	{
		//Activate the game over text.
		gameOvertext.SetActive (true);
		//Set the game to be over.
		gameOver = true;
	}

    /*public void Save()
    {
        FileStream fs = new FileStream(Application.dataPath + "/save.txt", FileMode.Create);
        byte[] bytes = new UTF8Encoding().GetBytes(highest.ToString());
        fs.Write(bytes, 0, bytes.Length);
        fs.Close();
    }*/
    /*public void Save0()
    {
        highest = 0;
        FileStream fs = new FileStream(Application.dataPath + "/save.txt", FileMode.Create);
        byte[] bytes = new UTF8Encoding().GetBytes(highest.ToString());
        fs.Write(bytes, 0, bytes.Length);
        fs.Close();
    }
    public void Load()
    {
        FileStream fs = new FileStream(Application.dataPath + "/save.txt", FileMode.Open);
        byte[] bytes = new byte[10];
        fs.Read(bytes, 0, bytes.Length);
        string s = new UTF8Encoding().GetString(bytes);
        highest = int.Parse(s);
        highestText.text = "Highest: " + highest.ToString();
    }*/
}
