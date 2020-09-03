using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDamage : MonoBehaviour
{

    PlayerLife life;
    Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        life = GameObject.Find("Vidas Jugador 1").GetComponent<PlayerLife>();
        manager = GameObject.Find("GameManager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Rayo"))
        {
            life.Resurrection();
        }
    }
}
