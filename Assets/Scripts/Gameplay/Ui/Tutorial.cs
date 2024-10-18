using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public ChatSystem chatContinue;
    public TutorialGrid tutorialGrid;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (tutorialGrid.isClicked == true)
        {
            chatContinue.enabled = true;
            this.enabled = false;
        }
    }
    private void OnEnable()
    {
        foreach (Transform obj in gameObject.transform)
        {
            obj.gameObject.SetActive(true);
        }
    }
    private void OnDisable()
    {
        foreach (Transform obj in gameObject.transform)
        {
            obj.gameObject.SetActive(false);
        }
    }
}
