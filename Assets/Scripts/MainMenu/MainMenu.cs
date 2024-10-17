using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject selectMenu;

    private void Awake()
    {
        SaveLoadData.LoadScoreData();
    }

    public void SelectMenuActive(bool isActive)
    {
        selectMenu.SetActive(isActive);
    }

    public void SelectStage(int stage)
    {
        SceneManager.LoadScene(stage);
        PlayerPrefs.SetInt("stage", stage);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
