using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.GetInstance();
    }

    public void ChangeScene(int index)
    {
        soundManager.PlayButton("Button1");
        SceneManager.LoadScene(index);
    }

    public void LoadCurrentScene()
    {
        soundManager.PlayButton("Button1");
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void NextScene()
    {
        soundManager.PlayButton("Button1");
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("stage", sceneIndex + 1);
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void Exit()
    {
        soundManager.PlayButton("Button1");
        Application.Quit();
    }
}
