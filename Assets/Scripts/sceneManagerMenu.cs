    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(AudioSource))]

public class sceneManagerMenu : MonoBehaviour

{
    AudioSource audio;
    Manager manager;
    [SerializeField] GameObject panelSelectornivel;
    
    private void Start() {

       
        audio=GetComponent<AudioSource>();
        // manager = GameObject.Find("GameManager").GetComponent<Manager>();          
    }
    public void PlayGame(){

        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            SceneManager.LoadScene("CMCompleteWorld",LoadSceneMode.Single);
        }
        else
        {
            panelSelectornivel.SetActive(true);
        }
       
        audio.Play();
        // SceneManager.LoadScene("CMCompleteWorld",LoadSceneMode.Single);
    }
    
    public void ClosePanelSelectorLevel()
    {
        panelSelectornivel.SetActive(false);
    }
    public void GoToMenu(){
        audio.Play();
        SceneManager.LoadScene("CMProvitionalMenu");
    }
}
