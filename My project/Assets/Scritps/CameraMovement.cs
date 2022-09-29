using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	const int baseCameraSize = 5;
	public Camera camera;
	Vector3 goToThisSpot = new Vector3(0,0,-10);
	
	
    // Start is called before the first frame update
    void Start()
	{
    }

    // Update is called once per frame
    void Update()
	{
		transform.position = Vector3.Lerp(camera.transform.position, goToThisSpot, .01f);
		
		
	}
    
    
	public void FocusOnThing(GameObject focusOn)
	{
 
		goToThisSpot = new Vector3(
			focusOn.transform.position.x, 
			focusOn.transform.position.y, 
			camera.transform.position.z);
		
	}
}
