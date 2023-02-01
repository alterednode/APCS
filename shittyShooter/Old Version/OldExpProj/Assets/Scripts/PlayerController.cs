using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private variables
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private GameObject rotator;
    private Camera Camera;
    private GameObject weaponLeft;
    private GameObject weaponRight;
    private GameManager gameManager;




    // vars for shooting things
    Shooting shootScript;

    public float maxRayDistance = 500;
    private bool leftShot = false;
    private Vector3 aimLocation;
    public GameObject bullet;
    private bool canShoot = true;
    public float fireRate = 2;


    //for messing around
    public GameObject myPrefab;



    // public bools for player states(?)
    public bool isSprinting = false;
    public bool isTouchingGround;
    public bool canJump = false;


    // public variables for controlling movement things
    public float playerSpeed = 400f;
    public float strafeRatio = 2.0f;
    public float playerJumpForce = 3;
    public float sprintMultiplier = 1.5f;
    public float airSpeedReduction = 2f;


   


    // Start is called before the first frame update
    void Start()
    {
        shootScript = gameObject.GetComponent<Shooting>();
        //find the game manager script, set it to game Manager
        gameManager = GameObject.Find("Game Manager").GetComponent < GameManager > ();
        //get the player's rigidbody
        playerRb = GetComponent<Rigidbody>();
        //get the focal point for the camera
        focalPoint = GameObject.Find("Focal Point");
        // get the thing that controlls the rotation of things for the player
        rotator = GameObject.Find("Rotating");
        // get the camera
        Camera = Camera.main;
        //get the left and right weapons
        weaponLeft = GameObject.Find("Weapon Left");
        weaponRight = GameObject.Find("Weapon Right");

        //FOV 100
        Camera.fieldOfView = 70;




    }

    // Update is called once per frame
    void Update()
    {
        // Add a check to see if the game is active
        if (gameManager.isGameActive)
        {
            
            CheckSprint();
            PlayerWASD();
            Jump();
        }
        else
        {
            
        }
        
    }

    private void FixedUpdate()
    {
        UpdateWeaponPos();
        if (gameManager.isGameActive)
        {
            Fire();
        }
    }

    

    void Fire()
    {
        if (Input.GetKey(KeyCode.Mouse0) && canShoot)
        {

            if (leftShot)
            {
                shootScript.Shoot(weaponRight.transform);
                

                leftShot = false;
                

            }
            else
            {

                shootScript.Shoot(weaponLeft.transform);

                leftShot = true;
                
            }

            StartCoroutine(FireCooldown());

        }
    }

    IEnumerator FireCooldown()
    {
        canShoot = false;

         yield return new WaitForSeconds(1/fireRate);
        canShoot = true;
    }

    void UpdateWeaponPos() // make variables for these values NO MAGIC NUMBERS :(
    {


        // https://docs.unity3d.com/ScriptReference/Transform.LookAt.html

        //since we are shooting from the sides of the player we need a spot for the guns to focus on.
        Ray ray = Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // A ray through the middle of the screen
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxRayDistance))
        {
            if (hit.distance < 2.0f)
            { // if the player is too close to the thing, default to a distance of two from the middle of the camera
                aimLocation = Camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)) + (Camera.transform.forward * 2);
            }
            else
            { //if the raycast both hits something and is greater than two, use the hit location
                aimLocation = hit.point;


            }
        }
        else
        {
            //if the raycast hits nothing, default to the max distance of the raycast
            aimLocation = Camera.transform.position + (Camera.transform.forward * maxRayDistance);

        }

        //point the weapons at the aim location
        weaponRight.transform.LookAt(aimLocation);
        weaponLeft.transform.LookAt(aimLocation);


    }





    void PlayerWASD()
    {
        

        //if the player is sprinting, reduce strafe effectiveness, and increace speed
        if (isSprinting)
        {
            playerRb.AddForce((BaseMovement("front/back")  * sprintMultiplier), ForceMode.Acceleration);
            playerRb.AddForce((BaseMovement("strafing") / sprintMultiplier), ForceMode.Acceleration);
        }

        else
        {//base movement if the player is not sprinting or in the air
            playerRb.AddForce(BaseMovement("front/back"), ForceMode.Acceleration);
            playerRb.AddForce(BaseMovement("strafing"), ForceMode.Acceleration);
        }

    }

    Vector3 BaseMovement(string type)
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the vertical and horiziontal input


        if (type == "front/back")
        {   //takes w & s or vert joystick and multiplies it by the speed and the thing that fixes the stuttery thing
            return (focalPoint.transform.forward * playerSpeed * verticalInput * Time.deltaTime);
        }
        else if (type == "strafing")
        {//takes a & d or horiz joystick and multiplies it by the speed and the thing that fixes the stuttery thing
            return (focalPoint.transform.right * horizontalInput * (playerSpeed / strafeRatio) * Time.deltaTime);
        }
        else
        {

            //send an error if we are using a movement type not in here
          //  Debug.LogError(type + "   is not in the BaseMovement options");
            // 
            return (Vector3.zero); // no movement if there is an error
        }



    }



    void CheckSprint()
    {

        // if the shift key is down make sprinting true
        if (Input.GetKey("left shift"))
        {
            Camera.fieldOfView = 73;
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
            Camera.fieldOfView = 70;
        }

    }

    void Jump()
    {

        //when the player presses space, add vertical force
        if (Input.GetKeyDown("space") && canJump)
        {
            playerRb.AddForce(focalPoint.transform.up * playerJumpForce, ForceMode.Impulse);
            canJump = false;
        }
        
            
    }


    //TODO: actually know when the player is on the ground



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jumpable"))
        {
            // let char jump
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        return;
    }



}
