using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
	public string powerupType;
	//Shrink, Grow, SpeedUp, SlowDown
	
	float fallingSpeed;
	GameManager gameManager;
    // Start is called before the first frame update
    void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	    fallingSpeed = gameManager.powerupSpeed;
    }

    // Update is called once per frame
    void Update()
    {
	    transform.Translate(Vector2.down * fallingSpeed * Time.deltaTime);
    }
}
