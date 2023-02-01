using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject player;
    private Rigidbody missileRb;

    public float rotationSpeed = 3.0f;
    public float maxTrackingDistance = 500;
    public float speed = 10;

    private GameObject target;
    private GameObject aimSource;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        missileRb = gameObject.GetComponent<Rigidbody>();
        target = player;
        aimSource = transform.gameObject;

        //missileRb.AddForce(aimSource.transform.forward * 10, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.isGameActive)
        {
            transform.position += (transform.forward * Time.deltaTime * speed);


            if (LineOfSightToPlayer() == true)
            {
                AimAt();
                            }

            if (Vector3.Distance(gameObject.transform.position, player.transform.position) > 1500)
            {
                Destroy(gameObject);
            }


        }
    }
    private void AimAt()
    {
        Quaternion targetDirection = Quaternion.LookRotation(((target.transform.position + player.GetComponent<Rigidbody>().velocity/2) - aimSource.transform.position).normalized);
        //rotate us over time according to speed until we are in the required rotation

        aimSource.transform.rotation = Quaternion.RotateTowards(aimSource.transform.rotation, targetDirection, Time.deltaTime * rotationSpeed);

    }

    private bool LineOfSightToPlayer()
    {
        Vector3 raycastDir = target.transform.position - transform.position;



        RaycastHit hit;

        if (Physics.Raycast(transform.position, raycastDir, out hit, maxTrackingDistance))
        {
            
            if (hit.transform.tag == "Player")
            {
                
                return true;
            }
            else
            {
                
            }
        }
        
            // send raycast directly towards player, ignore forward direction, if false go straight, true; turn
            return false;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          //  Debug.Log("hitplayer");
            player.GetComponent<PlayerHealth>().takeDamage(10);
        }


        Destroy(gameObject);
    
    }

    public void ShotDown()
    {
        gameManager.UpdateScore(1);
        Destroy(gameObject);
    }
}
