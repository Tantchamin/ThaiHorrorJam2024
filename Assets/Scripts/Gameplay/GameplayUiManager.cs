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

    public void OpenFinishUi(bool isWin)
    {
        finishText.text = isWin ? "You did it!" : "Little Red Riding Hood got you...";
        nextButton.interactable = isWin;
        finishUi.SetActive(true);
    }
    

}
