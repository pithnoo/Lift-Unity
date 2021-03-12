using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public CircleTransition circleTransition;
    public string sceneName;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            loadNextLevel();
        }
    }

    public void loadNextLevel(){
        StartCoroutine("LoadLevel");
    }

    IEnumerator LoadLevel(){
        circleTransition.StartCoroutine("LevelTransition");
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(sceneName);
    }
}
