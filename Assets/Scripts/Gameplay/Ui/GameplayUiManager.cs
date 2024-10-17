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

    public List<Image> starList;

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
    

}
