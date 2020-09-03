using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LvlBonus : Singleton<LvlBonus>
{
    private int scoreBonus;
    private int bubbleCounter;

    public int ScoreBonus
    {
        get { return scoreBonus; }
        set { scoreBonus = value; }
    }
    public int BubbleCounter
    {
        get { return bubbleCounter; }
        set { bubbleCounter = value; }
    }

    [SerializeField] private GameObject panel;
    [SerializeField] private Text ballonsText;
    [SerializeField] private Text scoreballonText;
    
    protected override void Awake(){

    }
    

    public void ActivePanel()
    {
        panel.SetActive(true);       

        if(ballonsText != null && scoreballonText != null)
        {
            ballonsText.text = bubbleCounter.ToString();

        if(Manager.Instance.CurrentLevel==4){

             scoreballonText.text = bubbleCounter.ToString() + " x 500";          

             scoreBonus = bubbleCounter * 500;

        }
        if(Manager.Instance.CurrentLevel==9){
             scoreballonText.text = bubbleCounter.ToString() + " x 700";          

             scoreBonus = bubbleCounter * 700;

        }

           

        }

        Time.timeScale = 0;
    }


}



