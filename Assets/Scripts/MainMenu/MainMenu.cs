using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject selectMenu;

    public void SelectMenuActive(bool isActive)
    {
        selectMenu.SetActive(isActive);
    }

    public void SelectStage(int stage)
    {
        SceneManager.LoadScene(stage);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
