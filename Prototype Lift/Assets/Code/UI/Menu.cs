using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public LevelLoader levelLoader;
    public AudioManager audioManager;
    public GameObject instructions;
    public GameObject instructions2;
    public GameObject weaponSelectScreen;
    // Start is called before the first frame update
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void StartGame(){
        //start game
        weaponSelectScreen.SetActive(true);
        audioManager.Play("Select");
    }

    public void LoadInstructions(){
        //load instructions
        instructions.SetActive(true);
        audioManager.Play("Select");
    }
    public void QuitGame(){
        //audioManager.Play("Pause");
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void ExitInstructions(){
        instructions.SetActive(false);
        audioManager.Play("Select");
    }

    public void ExitInstructions2(){
        instructions2.SetActive(false);
        audioManager.Play("Select");
    }

    public void ExitWeaponSelect(){
        weaponSelectScreen.SetActive(false);
        audioManager.Play("Select");
    }
}
