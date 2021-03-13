using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public AudioManager audioManager;

    void Start() {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void loadLevel(int sceneNumber){
        StartCoroutine(LoadLevel(sceneNumber));
    }

    public IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(levelIndex);
    }
}
