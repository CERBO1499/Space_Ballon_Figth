﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Enums;

public class EnemyHurt : MonoBehaviour
{

[SerializeField] private float gravityTotal=0f;
[SerializeField] private float timeToResurrection=3f;

EnemieType enemieType;


    private EnemiIA enemiIA;
    private EnemyLife enemyLife; 
    private Rigidbody rbEnemy,rbenemyGFX;
    private ChangeMaterial changeMaterial;
private void Start()
  {
    enemyLife=GetComponentInChildren<EnemyLife>();
    rbEnemy=GetComponent<Rigidbody>();  
    enemieType=GetComponent<EnemieType>();
    changeMaterial=GetComponentInChildren<ChangeMaterial>();
        
  }
 public void enemyResurrection()
  {
    enemiIA.isStoppedIA=false;   
    enemyLife.Lifes++;
    enemyLife.ball.SetActive(true);
    enemyLife.BallTrue = true;


    switch (enemieType._enemies)
    {
        case Eenemie.Basico:        
        enemieType._enemies=Eenemie.Medio;
        enemieType.BeginEnemie();
        changeMaterial.BeginEnemieMaterialType();



        break;

        case Eenemie.Medio:
        enemieType._enemies=Eenemie.Alto;
        enemieType.BeginEnemie();
        changeMaterial.BeginEnemieMaterialType();

        break;

        case Eenemie.Alto:
        enemieType._enemies=Eenemie.Alto;
        enemieType.BeginEnemie();
        changeMaterial.BeginEnemieMaterialType();




        break;
        
    }


  } 

public void enemyHurtFalling()
{
  enemiIA = GetComponent<EnemiIA>();
  enemiIA.isStoppedIA = true;
 
}


}
