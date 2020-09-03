using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
[RequireComponent(typeof(AudioSource))]

public class Manager : Singleton<Manager>
{

    //Carlos Agrego el singleton en la linea 6 que dice Singleton<Manager>, antes solo heredaba de MonoBehaviour
    [SerializeField] Checkpoint finalCheckpoint;
    [SerializeField] string winScene;
    [SerializeField] string lossScene;
    [SerializeField] PlayerLife vidaJugador;
    [SerializeField] int currentLevel=1;
    [SerializeField] Checkpoint[] checkpoints;
    Vector3 spawnPoint;
    [SerializeField] Transform[] spawners;    

    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public Vector3 SpawnPoint { get => spawnPoint; set => spawnPoint = value; }
    private AudioSource audio;

    // Start is called before the first frame update

    // Update is called once per frame

    //No borrar el override ni por el P****
    protected override void Awake(){
                    
    }
    void Update()
    {
        if (finalCheckpoint.Pass == true)
        {
            UIController.Instance.Score=0;
            
            SceneManager.LoadScene(winScene);
            
            
            
        }
        else if (vidaJugador.Lives == 0)
        {
            UIController.Instance.Score=0;
            audio=GetComponent<AudioSource>();
            audio.Play();
            SceneManager.LoadScene(lossScene);
            // MOD for player prefs
            PlayerPrefs.SetInt("CurrentLevel",currentLevel);  

    
            

        }
        CheckPointManager();
    }

    void CheckPointManager()
    {

        if(SpawnPoint==null || SpawnPoint != spawners[CurrentLevel - 1].position)
        {
            SpawnPoint = spawners[CurrentLevel - 1].position;
        }

        foreach(Checkpoint check in checkpoints)
        {
            if (int.Parse(check.Level) == CurrentLevel)
            {
                if (check.enabled == false)
                {
                    check.enabled=true;
                 
                }
            }

            else
            {
                if(check.enabled == true)
                {
                    check.enabled=false;
                }
            }
        }
    }
}
