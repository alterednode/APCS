using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	GameObject ball;
	GameObject gameOver;
	
	public float powerupSpeed;
	
	public List<Sprite> blockSprites;
	
	public List<GameObject> powerups;
	
	//percent chance of a powerup dropping
	public float powerupDropChance;
	
	
	
    // Start is called before the first frame update
    void Start()
    {
	    ball = GameObject.Find("ball");
	    gameOver = GameObject.Find("gameOver");
	    
	    // hide game over text before the game starts
	    gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
	    if ((ball.transform.position.y) < -200)
	    {
	    	gameOver.SetActive(true);
	    }
    }
    
    
	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
