using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{    
    public void Continue()
    {
        Time.timeScale = 1;
        UIController.Instance.AñadirPuntaje(LvlBonus.Instance.ScoreBonus);     
        LvlBonus.Instance.ScoreBonus=0;   
    }

}
