using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueGameManager :  Singleton<TrueGameManager>
{
    int currentLevelGameManager=1; 
    Vector3 posInicial=new Vector3();
    public int CurrentLevelGameManager { get => currentLevelGameManager; set => currentLevelGameManager = value; }
    public Vector3 PosInicial { get => posInicial; set => posInicial = value; }    


    



}
