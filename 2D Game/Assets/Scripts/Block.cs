using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	GameObject GameOverText;
	GameManager gameManager;
	SpriteRenderer renderer;
    
	private void Start() {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		
		renderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collisionInfo) {
        //Destroy the block
        

	    GameObject.Find("Score").GetComponent<ScoreScript>().AddToScore();
        
	    //downgrades or destroies the block
	    DownGradeBlock();
	    AttemptPowerupDrop();
	     
	    
	    
		
        
    }
	void DownGradeBlock()
	{
		int	currentSpriteInt = gameManager.blockSprites.IndexOf(renderer.sprite);
		if (currentSpriteInt != 4)
		{
	
			renderer.sprite = gameManager.blockSprites[currentSpriteInt+1];
		}else
		{
			Destroy(gameObject);
		}
	}
	void AttemptPowerupDrop()
	{
		if (Random.value*100<gameManager.powerupDropChance)
		{
			GameObject powerup = Instantiate(gameManager.powerups[Random.Range(0,gameManager.powerups.Count)]);
			powerup.transform.position = transform.position;
		}
	}
	
}
