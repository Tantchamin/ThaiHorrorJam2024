using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayUiManager : MonoBehaviour
{
    public GameplayManager gameplayManager;
    public GameObject finishUi;
    public Button nextButton;
    public TMP_Text finishText;
    public TMP_Text stageText;
    public TMP_Text turnText;
    public GameObject pauseUi;
    public GameObject endingUi;
    public TMP_Text endingText;

    public List<Image> starList;

    private void Start()
    {
        stageText.text = $"Stage {gameplayManager.stageNumber}";
    }

    public void OpenFinishUi(bool isWin)
    {
        if (gameplayManager.stageNumber == 5 && isWin == true)
        {
            int sum = ScoreData.GetAllStar();
            endingText.text = sum > (ScoreData.stageStars.Length * 3) ? "Good Ending" : "Bad Ending";
            endingUi.SetActive(true);
            return;
        }
        finishText.text = isWin ? "You did it!" : "Little Red Riding Hood got you.";
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
        bool isOpen = pauseUi.activeSelf;
        pauseUi.SetActive(!isOpen);
    }
    
}
