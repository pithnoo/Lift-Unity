using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public AudioManager audioManager;
    public LevelManager levelManager;
    public PlayerController playerController;
    public int selectedWeapon = 0;

    void Start() {
        //audioManager = FindObjectOfType<AudioManager>();
        levelManager = FindObjectOfType<LevelManager>();
        playerController = FindObjectOfType<PlayerController>();
    }

    public void loadLevel(int sceneNumber){
        StartCoroutine(LoadLevel(sceneNumber));
    }

    public void loadLevelAndSave(int sceneNumber){
        StartCoroutine(LoadLevelAndSave(sceneNumber));
    }

    public IEnumerator LoadLevel(int levelIndex){
        //Cursor.visible = false;
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(levelIndex);
    }

    public IEnumerator LoadLevelAndSave(int levelIndex){
        //Cursor.visible = false;
        levelManager.convertToGems();

        PlayerPrefs.SetInt("CurrentLevel", levelManager.currentLevel);
        PlayerPrefs.SetInt("CurrentGems", levelManager.gemCount);
        PlayerPrefs.SetFloat("CurrentHealth", playerController.currentHealth);

        //yield return new WaitForSeconds(transitionTime);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(levelIndex);
    }
}
