using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System.Linq;// for checking contains()

public class GameManager : MonoBehaviour
{

    // stores UI stuff
    public TextMeshProUGUI scoreText;
    public GameObject titleScreen;
    public GameObject restartScreen;
    public TextMeshProUGUI healthText;
    public Button quit;
    

    public int score = 0;
    public float spawnRate = 10.0f;

    private GameObject player;
    public GameObject stationaryEnemy;
    public GameObject missliePrefab;
    public GameObject bulletPrefab;

    public bool isGameActive = false;

    public float typeOfGame = 0;

    public int starterSpawns;

    // Enemy location coordination
    //public List<> spawnLocations;
    //public List<> enemySpawnedAt;


    public GameObject[] spawnLocations;
    public List<int> avalibleLocations;
    public bool spawnedThing = false;

    public float spawnDistanceFromPlayer = 20;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        // get all of the locations where enemies can spawn and put them in an array
        SpawningLocationsSetup();
        Cursor.lockState = CursorLockMode.Confined;

        restartScreen.gameObject.SetActive(false);


        //temporary
    }

    private void Update()
    {
        if (isGameActive)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    void SpawningLocationsSetup()
    {
        // find all the spawn locations, puut in a list
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnLocation");

        foreach (GameObject spawnLocation in spawnLocations)
        {
            
            spawnLocation.SetActive(false);// hide them before we start the game

            // fill a list with the index of each avalible spawnlocation
            avalibleLocations.Add(
                System.Array.IndexOf(spawnLocations, spawnLocation)
                );            
        }
    }

  


    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: \n" + score;
    }

    public void DisplayHealth(int health)
    {
        healthText.text = "Health: " + health;
    }

    // While game is active spawn a random target
    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {

            // spawn rate, plus / minus 1
            // higher chances of lower number with every enemy killed
            float calculatedSpawnRate = spawnRate + Random.Range((-1f - (score / 100)), 1.0f);

            yield return new WaitForSeconds(calculatedSpawnRate);

            // random num from avalibleLocations
            


                if (!(avalibleLocations.Count == 0)) {
                    StartCoroutine(Spawner());
                    spawnedThing = true;


                }
                
            

        }
    }


    IEnumerator Spawner()
    {
        int randomSpawnNumber = avalibleLocations[Random.Range(0, avalibleLocations.Count)];
        GameObject spawnlocation = spawnLocations[randomSpawnNumber]; // var to hold the spawnlocation
        while ((Vector3.Distance(player.transform.position, spawnlocation.transform.position)) < spawnDistanceFromPlayer)
        {
            yield return new WaitForSeconds(1);
           // Debug.Log("player too close");
        }


        //Spawn the enemy, make spawnlocation parent
        GameObject enemySpawning = Object.Instantiate(stationaryEnemy, spawnlocation.transform.position, spawnlocation.transform.rotation, spawnlocation.transform);
        
        enemySpawning.transform.localScale = new Vector3((1 / spawnlocation.transform.lossyScale.x), (1 / spawnlocation.transform.lossyScale.y), (1 / spawnlocation.transform.lossyScale.z));
        spawnlocation.SetActive(true);

        // remove avalible location from list
        avalibleLocations.Remove(randomSpawnNumber);
    }

    public void EnemyDeath(GameObject deadThingLocation)
    {
        avalibleLocations.Add(System.Array.IndexOf(spawnLocations, deadThingLocation));
        deadThingLocation.SetActive(false);
        
    }


    public void GameStart() //what to do when the game starts
    {
        isGameActive = true;
        StartCoroutine(SpawnTargets());
        score = 0;
        UpdateScore(0);
        restartScreen.gameObject.SetActive(false);
        titleScreen.SetActive(false);
        quit.gameObject.SetActive(false);


        for (int i = 0; i < starterSpawns; i++)
        {
            StartCoroutine(Spawner());
        }




    }

    public void GameOver()
    {
        restartScreen.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
        
    }
}