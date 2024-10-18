using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGrid : MonoBehaviour
{
    public bool isClicked = false;
    private void OnMouseDown()
    {
        isClicked = true;
    }
}
