using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayUiManager : MonoBehaviour
{
    public GameObject finishUi;
    public Button nextButton;
    public TMP_Text finishText;
    public TMP_Text stageText;
    public TMP_Text turnText;
    public GameObject PauseUi;

    public List<Image> starList;

    private void Start()
    {
        int stageNumber = PlayerPrefs.GetInt("stage");
        stageText.text = $"Stage {stageNumber}";
    }

    public void OpenFinishUi(bool isWin)
    {
        finishText.text = isWin ? "You did it!" : "Little Red Riding Hood got you...";
        nextButton.interactable = isWin;
        finishUi.SetActive(true);
    }

    public void CollectStar(int index)
    {
        starList[index].color = Color.white;
    }

    public void ResetStar()
    {
        foreach(Image star in starList)
        {
            star.color = Color.black;
        }
    }

    public void TurnAdjust(int turn)
    {
        turnText.text = $"Turn : {turn}";
    }
    public void OpenClosePauseUi()
    {
        bool isOpen = PauseUi.activeSelf;
        PauseUi.SetActive(!isOpen);
    }
    
}
