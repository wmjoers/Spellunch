using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private GameController gc;
    private Text scoreLabel;

    void Awake()
    {
        scoreLabel = GetComponent<Text>();        
    }

    void Start()
    {    
        gc = GameController.shared;    
        UpdateScoreLabel();
    }

    private void UpdateScoreLabel()
    {
        scoreLabel.text = gc.score.ToString();
    }

    public void AddScore()
    {
        gc.score += 10;
        UpdateScoreLabel();
    }

}
