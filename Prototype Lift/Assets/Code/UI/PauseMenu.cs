using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public LevelManager levelManager;
    public LevelLoader levelLoader;
    public AudioManager audioManager;

    void Start() {
        levelManager = FindObjectOfType<LevelManager>();
        levelLoader = FindObjectOfType<LevelLoader>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && !levelManager.isGameOver){
            if(GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        audioManager.Play("Pause");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void Pause(){
        audioManager.Play("Pause");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void LoadMenu(){
        audioManager.Play("Select");
        levelLoader.loadLevel(0);
        Time.timeScale = 1;
        audioManager.Play("MenuTheme");
    }

    public void QuitGame(){
        //audioManager.Play("Pause");
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
