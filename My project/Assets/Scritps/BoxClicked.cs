using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BoxClicked : MonoBehaviour
{
	GameManager gameManager;
	CameraMovement cameraScript;
    bool clickStartedHere = false;

// Start is called before the first frame update
    void Start()
    {
	    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	    cameraScript = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
    }


    private void OnMouseDown() {
        clickStartedHere = true;
    }
    private void OnMouseExit() {
        clickStartedHere = false;
    }

    /// <summary>
    /// Called every frame while the mouse is over the GUIElement or Collider.
    /// </summary>
    void OnMouseOver()
    {
        if(Input.GetMouseButtonUp(0) && clickStartedHere){
	        Debug.Log(gameObject.name + gameObject.transform.parent.parent.name);
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
        newPiece.transform.parent = gameObject.transform.parent.parent;
        
		gameManager.xPlayerTurn = !gameManager.xPlayerTurn;
		//if destinationPlayable
        

        // Removed Camera Movement for gameplay Reasons
		// cameraScript.FocusOnThing(gameObject.transform.parent.gameObject);//,2.0f

        gameObject.SetActive(false);
	}
    
    
    
}
