using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
[RequireComponent(typeof(AudioSource))]
public class PlayerLife : MonoBehaviour
{
    //CM Mods
    [SerializeField] GameObject cmCam;
    [SerializeField] bool isShield = false;
    public bool IsShield { get => isShield; set => isShield = value; }

    private EnemiIA enemyIA;

    [SerializeField] ParticleSystem poof;

    //CM Mods



    [SerializeField]private int lifes = 2;    
    [SerializeField]private int lives = 3;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject life1;
    [SerializeField] private GameObject life2;
    [SerializeField] private GameObject padre;
    [SerializeField] private GameObject[] livesImages = new GameObject[2];  
    private AudioSource aud;


    private Quaternion rotGlobo2;


    //Andres
    Manager manager;

    public int Lifes
    {
        get { return lifes; }
        set { lifes = value; }
    }
    public int Lives
    {
        get { return lives; }
        set { lives = value; }
    }
    private Vector3 spawn;
    // private Vector3 life2Pos;
   

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<Manager>();        
        spawn = manager.SpawnPoint;
        rotGlobo2=life2.transform.rotation;
        aud = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag == "Enemy")
        {
            enemyIA = other.gameObject.GetComponentInParent<EnemiIA>();
            //CM Mods
            if (!isShield && enemyIA.isStoppedIA == false)
            {
                TakeDamage();
                poof.Play();

            }
            //CM Mods
        }
        else if(other.gameObject.tag == "Rayo")
        {
            Resurrection();
        }

        if (lifes == 0 )
        {
            
            life2.transform.position = new Vector3(padre.transform.position.x+0.4f, padre.transform.position.y-0.3f, padre.transform.position.z);
            life2.transform.rotation = rotGlobo2;
            Resurrection();
        }        
    }

   
    void TakeDamage()
    {
        lifes--;
        isShield=true;
        StartCoroutine(ShieldTimeAfterTakeDamage(1.2f));
        aud.Play();


        if(lifes == 1)
        {            
            life1.SetActive(false);
            life2.transform.position = new Vector3(padre.transform.position.x+0.15f, padre.transform.position.y, padre.transform.position.z);
            life2.transform.rotation = Quaternion.identity;
        }

        //CM Mods
       
        //CM Mods
    }

    public void Resurrection()
    {
        //CM Mods
                      
           player.transform.position = manager.SpawnPoint;
           lives -= 1;
           lifes = 2;
           life1.SetActive(true);

            if(lives > 1)
            {
                livesImages[0].SetActive(false);
            }
            else
            {
                livesImages[1].SetActive(false);
            }


           
        

        // player.transform.position = spawn;
        // lives = 1;
        // lifes = 2;
        // life1.SetActive(true);

        //CM Mods
    }
     private IEnumerator ShieldTimeAfterTakeDamage ( float time)
    {
        yield return new WaitForSeconds(time);

        IsShield = false;
    }
}
