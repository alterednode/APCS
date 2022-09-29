using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BoxClicked : MonoBehaviour
{
	GameManager gameManager;
	CameraMovement cameraScript;

// Start is called before the first frame update
    void Start()
    {
	    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	    cameraScript = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
    }


    /// <summary>
    /// Called every frame while the mouse is over the GUIElement or Collider.
    /// </summary>
    void OnMouseOver()
    {
        if(Input.GetMouseButtonUp(0)){
	        Debug.Log(gameObject.name + gameObject.transform.parent.gameObject.name);
	        ThisBoxClicked();
            
        }
    }



    

    // Update is called once per frame
    void Update()
    {
	   
    }
	
	void ThisBoxClicked()
	{
		GameObject newPiece = Instantiate(gameManager.prefabXO[Convert.ToInt32(gameManager.xPlayerTurn)]);
		newPiece.transform.position = gameObject.transform.position;
		gameManager.xPlayerTurn = !gameManager.xPlayerTurn;
		
		cameraScript.FocusOnThing(gameObject.transform.parent.gameObject);
	}
    
    
    
}
