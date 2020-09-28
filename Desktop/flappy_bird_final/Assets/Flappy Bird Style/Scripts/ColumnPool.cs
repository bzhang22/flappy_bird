using UnityEngine;
using System.Collections;

public class ColumnPool : MonoBehaviour 
{
    public bool ishard;
	public GameObject columnPrefab;									//The column game object.
    public GameObject downColumn;
    public GameObject upColumn;
	public int columnPoolSize = 5;									//How many columns to keep on standby.
	public float spawnRate = 3f;									//How quickly columns spawn.
	public float columnMin = 1f;									//Minimum y value of the column position.
	public float columnMax = 3f;									//Maximum y value of the column position.
    
	private GameObject[] columns;									//Collection of pooled columns.
	private int currentColumn = 0;									//Index of the current column in the collection.

	private Vector2 objectPoolPosition = new Vector2 (-15,-25);		//A holding position for our unused columns offscreen.
	private float spawnXPosition = 12f;
    private float movingColumnXPosition = 12f;
    

	private float timeSinceLastSpawned;


	void Start()
	{
		timeSinceLastSpawned = 0f;

		//Initialize the columns collection.
		columns = new GameObject[columnPoolSize];
		//Loop through the collection... 
		for(int i = 0; i < columnPoolSize; i++)
		{
            //...and create the individual columns.
            if (ishard && (i%2==0 || i%3==0 || i%4==0))
            {
                if(i % 2 == 0) columns[i] = (GameObject)Instantiate(upColumn, objectPoolPosition, Quaternion.identity);
                else columns[i] = (GameObject)Instantiate(downColumn, objectPoolPosition, Quaternion.identity);

            }
			else columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
		}
	}


	//This spawns columns as long as the game is not over.
	void Update()
	{
		timeSinceLastSpawned += Time.deltaTime;

		if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
		{	
			timeSinceLastSpawned = 0f;
            Debug.Log(columns[currentColumn].name );
            if (columns[currentColumn].name == "upcolumn(Clone)" || columns[currentColumn].name == "downcolumn(Clone)")
            {
                float spawnYPosition = Random.Range(columnMin, columnMax);
                if (columns[currentColumn].name == "upcolumn(Clone)") {
                    columns[currentColumn].transform.position = new Vector2(movingColumnXPosition, -10);
                }
                else {
                    columns[currentColumn].transform.position = new Vector2(movingColumnXPosition, 13);
                }
                
            }
            else
            {
                //Set a random y position for the column
                float spawnYPosition = Random.Range(columnMin, columnMax);

                //...then set the current column to that position.
                columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            }
            
            
            
            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            currentColumn ++;

			if (currentColumn >= columnPoolSize) 
			{
				currentColumn = 0;
			}
		}
	}
}