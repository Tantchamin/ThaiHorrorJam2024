using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject checkBoxs;
    private GameplayManager gameplayManager;

    public void Init(GameplayManager gameplayManager)
    {
        this.gameplayManager = gameplayManager;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerMove(Vector3 position)
    {
        transform.position = position;
        ActivateCheckBox();
       // gameplayManager.UpdatePhase(GamePhase.enemy);
    }

    private void ActivateCheckBox()
    {
        StartCoroutine(OpenAndCloseCheckBox(0.5f));
    }

    IEnumerator OpenAndCloseCheckBox(float waitTime)
    {
        checkBoxs.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        checkBoxs.SetActive(false);
    }
}
