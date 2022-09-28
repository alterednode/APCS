using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    public float speed = 150;

    void FixedUpdate(){
        //Get horiz input
        float h = Input.GetAxisRaw("Horizontal");

        //set velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;


    }
	
    
	
	void OnTriggerEnter(Collider powerup)
	{
		if (powerup.CompareTag("Powerup"))
		{
			switch(powerup.gameObject.GetComponent<Powerup>().powerupType)
			{
				
			}
			//Use Switch statment to change what happens here
		}
	}
}
