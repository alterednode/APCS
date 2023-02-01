using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy : MonoBehaviour
{
    
    private GameManager gameManager;

    private GameObject player;
    public int timeBetweenShots = 4;
    public float rotationSpeed = 30.0f;
    public float maxTrackingDistance = 500;
    public GameObject aimSource;
    private GameObject target;
    Vector3 randomDirection;
    public int maxRotationToFire;

    public int health;


    public bool canShoot;

    public int pointValue = 10;

    public bool temp = false;
    public float lookTime = 0;
    public GameObject missile;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        player = GameObject.Find("Player");
        

        target = player;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            
            if (LineOfSightToPlayer() == true)
            {
                AimAt(target.transform.position);
               // Debug.Log(Quaternion.Angle(aimSource.transform.rotation, Quaternion.LookRotation((player.transform.position - aimSource.transform.position).normalized)));
                    if (canShoot && ((Quaternion.Angle(aimSource.transform.rotation, Quaternion.LookRotation((player.transform.position - aimSource.transform.position).normalized))) < maxRotationToFire))
                {
                    Object.Instantiate(missile, aimSource.transform.position + (aimSource.transform.forward * 2), aimSource.transform.rotation);
                    canShoot = false;
                    StartCoroutine(ShootCooldown());
                }
                
            }
            else
            {
                



                if (lookTime < 1.0f)
                {
                    randomDirection = GetRandomDirection();
                    lookTime = Random.Range(2,4);
                }
                else
                {
                    AimAt(randomDirection);
                }
                
                


            }
            
            }
        else
        {

        }
        if (temp) { Death(); }


        lookTime -= Time.deltaTime;
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    
    private void AimAt( Vector3 target) 
    {
        Quaternion targetDirection = Quaternion.LookRotation((target- aimSource.transform.position).normalized);
       
        //rotate us over time according to speed until we are in the required rotation
        
        aimSource.transform.rotation = Quaternion.RotateTowards(aimSource.transform.rotation, targetDirection, Time.deltaTime * rotationSpeed);

    }

    

    Vector3 GetRandomDirection()
    {
        Vector3 maxPosition = gameObject.transform.position + new Vector3(10, 5, 10);
        Vector3 minPosition = gameObject.transform.position + new Vector3(-10, -5, -10);
        var randomPosition = new Vector3(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y), Random.Range(minPosition.z, maxPosition.z));
        
        return randomPosition;
        
    }

    private bool LineOfSightToPlayer()
    {
        Vector3 raycastDir = target.transform.position - aimSource.transform.position;


        
        RaycastHit hit;

        if (Physics.Raycast(aimSource.transform.position, raycastDir, out hit, maxTrackingDistance))
        {
            if (hit.transform.tag == "Player"){
                return true; }
        }
        
        
            // send raycast directly towards player, ignore forward direction, if false go straight, true; turn
            return false;
        
    }

    public void TakeDamage(int damageToTake)
    {
        
        health -= damageToTake;
        
        if(health <= 0)
        {
            Death();
        }

    }

    void Death()
    {
            gameManager.EnemyDeath(gameObject.transform.parent.gameObject);
     //   gameManager.UpdateScore(pointValue);
        Destroy(gameObject);
        
    }



    


}
    
