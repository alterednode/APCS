using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour


{
    private GameManager gameManager;

    //for now, is a way to set custom sensitivity - later make so can also be changed through UI
    public float mouseSensitvity = 1.0f;
    public float verticalReduction = .5f;

    
    public GameObject player;
    public GameObject vertRotator;

    private float x_axis;
    private float y_axis;

    public float maxVertRotate = 45;
    public float minVertRotate = -45;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (gameManager.isGameActive)
        {
            Rotation();
        }

       transform.position = player.transform.position; // Move focal point with player (always do this or the camera will fall through the floor)
 
    }

    // I do not completely understand this.
    //https://stackoverflow.com/questions/57440730/how-to-limit-cameras-vertical-rotation-unity-3d
    private void Rotation()
    {
        x_axis += mouseSensitvity * Input.GetAxisRaw("Mouse X"); // speed = 2f;

        y_axis -= mouseSensitvity * Input.GetAxisRaw("Mouse Y") * verticalReduction;
        y_axis = Mathf.Clamp(y_axis, minVertRotate, maxVertRotate); // limits vertical rotation

        transform.eulerAngles = new Vector3(transform.rotation.y, x_axis, 0.0f);
        vertRotator.transform.eulerAngles = new Vector3(y_axis, x_axis, transform.rotation.z);
    }
}
