using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public LevelLoader levelLoader;
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void StartGame(){
        //start game
        audioManager.Play("Select");
    }

    public void LoadInstructions(){
        //load instructions
        audioManager.Play("Select");
    }
    public void QuitGame(){
        //audioManager.Play("Pause");
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
