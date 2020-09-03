using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class UIController : Singleton<UIController>
{
    private int score = 0;

    int lastScore;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    private string scoreText = "Score: ";

    public Text textScore;
    protected override void Awake(){
        
    }
    void Update()
    {
        if (textScore != null)
        {
            textScore.text = scoreText + score.ToString();            
        }
    }

    public void AñadirPuntaje(int scoreañadido)
    {
        score += scoreañadido;

        lastScore = scoreañadido;
    }

    public void ShowScore(GameObject enemy)
    {
        GameObject canvasScore = enemy.transform.GetChild(2).gameObject;
        Text scoreText = canvasScore.GetComponentInChildren<Text>();
        scoreText.text = lastScore.ToString();
        canvasScore.SetActive(true);
        StartCoroutine(ReleaseShowScore(canvasScore));
    }

    private IEnumerator ReleaseShowScore(GameObject canvasScore)
    {
        yield return new WaitForSeconds(0.5f);
        canvasScore.SetActive(false);
    }
}
    