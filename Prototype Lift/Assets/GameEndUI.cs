using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEndUI : MonoBehaviour
{
    public TextMeshProUGUI gemText;
    public LevelLoader levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        gemText.text = PlayerPrefs.GetInt("CurrentGems").ToString();
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    public void LoadMenu(){
        FindObjectOfType<AudioManager>().Play("Select");
        levelLoader.loadLevel(0);
        FindObjectOfType<AudioManager>().Play("MenuTheme");
    }
    public void QuitGame(){
        //audioManager.Play("Pause");
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
