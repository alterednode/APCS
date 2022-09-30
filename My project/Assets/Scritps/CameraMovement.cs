using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class CameraMovement : MonoBehaviour
{

	public float cameraMoveTime;
	public float focusedCameraSize;
	public float zoomedOutCameraSize;
	
	const int baseCameraSize = 5;
	public Camera theCamera;
	Vector3 goToThisSpot = new Vector3(0,0,-10);
	float goToThisCameraSize;
	
    // Start is called before the first frame update
    void Start()
	{
    }

    // Update is called once per frame
    void Update()
	{

		/*

			Removed Camera Movement for gameplay Reasons

		transform.position = Vector3.Lerp(transform.position, goToThisSpot, cameraMoveTime);
		//theCamera.orthographicSize  = Mathf.Lerp(theCamera.orthographicSize , goToThisCameraSize, cameraMoveTime);
		*/
		
	}
    
    /*

		Removed Camera Movement for gameplay Reasons

	//public void FocusOnThing(GameObject focusOn, float cameraSize)
	public void FocusOnThing(GameObject focusOn)
	{
		//goToThisCameraSize = cameraSize;
 
		goToThisSpot = new Vector3(
			focusOn.transform.position.x, 
			focusOn.transform.position.y, 
			theCamera.transform.position.z);
		
	}
	*/
}
