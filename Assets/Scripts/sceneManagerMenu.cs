using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(AudioSource))]

public class sceneManagerMenu : MonoBehaviour

{
    AudioSource audio;
    Manager manager;
    
    private void Start() {
        audio=GetComponent<AudioSource>();
        // manager = GameObject.Find("GameManager").GetComponent<Manager>();          
    }
    public void PlayGame(){

        audio.Play();
        SceneManager.LoadScene("Level CompleteWithBonus",LoadSceneMode.Single);
    }
    public void Level1(){

        audio.Play();
        SceneManager.LoadScene("Level CompleteWithBonus",LoadSceneMode.Single);
        // manager.CurrentLevel=
        PlayerPrefs.GetInt("CurrentLevel");
        
    }
    public void Level2(){

        audio.Play();
        SceneManager.LoadScene("Level CompleteWithBonus",LoadSceneMode.Single);
        // manager.CurrentLevel=
        PlayerPrefs.GetInt("CurrentLevel");

    }
    public void level3(){

        audio.Play();
        SceneManager.LoadScene("Level CompleteWithBonus",LoadSceneMode.Single);
        // manager.CurrentLevel=
        PlayerPrefs.GetInt("CurrentLevel");

    }

    public void GoToMenu(){
         audio.Play();
        // SceneManager.LoadScene("ProvitionalMenu");
    }
}
