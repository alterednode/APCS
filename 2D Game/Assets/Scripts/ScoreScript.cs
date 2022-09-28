using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{


    private int score = 0;  
    Text scoreText;
    private void Start() {
        scoreText = gameObject.GetComponent<Text>();
    } 



    public void AddToScore(){
        score ++;
        scoreText.text = ("Score:\n" + score);
    }
}
