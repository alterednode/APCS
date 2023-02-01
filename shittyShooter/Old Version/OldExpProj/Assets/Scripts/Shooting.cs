using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ShootingSystemL;
    [SerializeField]
    private ParticleSystem ShootingSystemR;
    [SerializeField]
    private ParticleSystem ImpactParticleSystem;
    [SerializeField]
    private TrailRenderer BulletTrail;
    [SerializeField]


    private void Awake()
    {
    }

    private void Start()
    {
    }

    public void Shoot(Transform spawnpoint)
    {
        
        {

            if(spawnpoint.name == "Weapon Right")
            {
                ShootingSystemR.Play();
            }
            else
            {
                ShootingSystemL.Play();
            }
            





            TrailRenderer trail = Instantiate(BulletTrail, spawnpoint.position + (spawnpoint.forward * .9f), Quaternion.identity);

            if (Physics.Raycast(spawnpoint.position, spawnpoint.forward, out RaycastHit hit, float.MaxValue))
            {



                StartCoroutine(SpawnTrail(trail, hit));



                if (hit.collider.gameObject.tag == "Enemy")
                {
                    hit.collider.gameObject.GetComponent<EnemyColDetect>().mainThing.GetComponent<StationaryEnemy>().TakeDamage(1);
                }
                if (hit.collider.gameObject.tag == "Missile")
                {
                    hit.collider.GetComponentInParent<MissileMovement>().ShotDown();
                    
                }
                Instantiate(ImpactParticleSystem, hit.point, Quaternion.LookRotation(hit.normal));
                

            }
            else
            {
                StartCoroutine(SpawnTrailMiss(trail, spawnpoint));
            }




        }
    }





    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit Hit)
    {
        float time = 0;
        Vector3 startPosition = Trail.transform.position;

        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, Hit.point, time);
            time += Time.deltaTime / Trail.time;

            yield return null;
        }
        Trail.transform.position = Hit.point;


        Destroy(Trail.gameObject, Trail.time);
    }


    private IEnumerator SpawnTrailMiss(TrailRenderer Trail, Transform hitSpot)
    {
        float time = 0;
        Vector3 startPosition = Trail.transform.position;

        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, hitSpot.transform.position + (hitSpot.transform.forward * 10), time);
            time += Time.deltaTime / Trail.time;

            yield return null;
        }
        Trail.transform.position = hitSpot.transform.position + (hitSpot.transform.forward * 10);


        Destroy(Trail.gameObject, Trail.time);
    }
}

