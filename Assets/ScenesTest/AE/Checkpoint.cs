using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] string level;
    Transform player;
    BoxCollider col;
    float deadZone;
    CinemachineFramingTransposer vcamBody;
    bool pass=false;

    [SerializeField]CinemachineVirtualCamera vcam;
    Manager gManager;

    EnemiIA enemiIA;

    public bool Pass { get => pass; set => pass = value; }
    public string Level { get => level; set => level = value; }

    private AudioSource aud;

    private GuardadoSerializado gSerializado;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        col = GetComponent<BoxCollider>();  
        vcamBody = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
        deadZone = vcamBody.m_DeadZoneHeight;
        gManager = GameObject.Find("GameManager").GetComponent<Manager>();
        aud=GetComponent<AudioSource>();
        gSerializado=GameObject.Find("GUARDADOPARTIDA").GetComponent<GuardadoSerializado>();

        
     

    }

    // Update is called once per frame
    void Update()
    {
        DistanceCheck();
    }

    void DistanceCheck()
    {
        if (player.transform.position.y > transform.position.y+1f /*&& Pass==false*/)
        {
            col.enabled = true;
            Pass = true; 
            //Debug.Log("Player Passed");
            gManager.CurrentLevel++;
            
            gSerializado.Guardar(Manager.Instance.CurrentLevel,Manager.Instance.SpawnPoint.x,Manager.Instance.SpawnPoint.y,Manager.Instance.SpawnPoint.z);
            
            aud.Play();
        }
        else if (player.transform.position.y < transform.position.y)
        {

            if (EnemyCount(Level) == 0)
            {
                col.enabled = false;
                vcamBody.m_DeadZoneHeight = deadZone;
                //Debug.Log("No ENEMIES");
            }
            else
            {
                //Debug.Log(EnemyCount(Level) + "Enemies");
                if (transform.position.y - player.transform.position.y < 7)
                {
                    vcamBody.m_DeadZoneHeight = 2;
                    //Debug.Log("Close to top");
                }

                else
                {
                    //Debug.Log("Far from top");
                    vcamBody.m_DeadZoneHeight = deadZone;
                }
                    
            }

        }
    }

    int EnemyCount(string level)
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(level);

        return enemies.Length;
    }
}
