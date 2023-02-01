using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public float lastTookDamage;
    bool canRegen = true;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.DisplayHealth(health);
        lastTookDamage = Time.time;
    }
    void Update()
    {
        if (health <= 0)
        {
            gameManager.GameOver();
        }

        if (Time.time - lastTookDamage > 10 && canRegen && health < 100)
        {
            StartCoroutine(RegenHealth());
        }
    }

    public void takeDamage(int damageTake)
    {
        health -= damageTake;
        gameManager.DisplayHealth(health);
        lastTookDamage = Time.time;
    }

    IEnumerator RegenHealth()
    {
        canRegen = false;
        yield return new WaitForSeconds(0.5f);
        health += 1;
        gameManager.DisplayHealth(health);
        canRegen = true;
    }
}
