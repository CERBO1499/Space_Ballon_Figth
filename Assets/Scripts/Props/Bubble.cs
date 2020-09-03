using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [Tooltip("Bubble Vertical Speed")]
    [SerializeField]
    float speed = 5f;

    
    private float lifeTime = 10;
    private bool isAlive = true;

    //[SerializeField]
    //int score = 500;

    public float Speed { get => speed; set => speed = value; }
    public float LifeTime{get=>lifeTime;set=>lifeTime=value;}

  
    private void Update()
    {
        transform.position += Vector3.up * Speed * Time.deltaTime;
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0 && isAlive)
        {
            ReleaseBubble();            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //UIController.Instance.AñadirPuntaje(score);
            LvlBonus.Instance.BubbleCounter += 1;
            ReleaseBubble();
        }
    }

    private void ReleaseBubble()
    {
        isAlive = false;       
        gameObject.SetActive(false);
        lifeTime=2;   

    }
}
