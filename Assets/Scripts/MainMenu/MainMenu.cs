using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject selectMenu;
    [SerializeField] private SelectMenu select;
    private SoundManager soundManager;

    private void Awake()
    {
        SaveLoadData.LoadScoreData();
    }

    private void Start()
    {
        soundManager = SoundManager.GetInstance();
        select.SetStageStar();
    }

    public void SelectMenuActive()
    {
        soundManager.PlayButton("Button1");
        bool isActive = selectMenu.activeSelf;
        selectMenu.SetActive(!isActive);
    }

    public void SelectStage(int stage)
    {
        soundManager.PlayButton("Button1");
        SceneManager.LoadScene(stage);
        PlayerPrefs.SetInt("stage", stage);
    }

    public void Quit()
    {
        soundManager.PlayButton("Button1");
        Application.Quit();
    }
}
