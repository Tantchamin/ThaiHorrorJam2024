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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            gameplayManager.GameFinish(true);
        }
        else if (other.CompareTag("Enemy"))
        {
            gameplayManager.GameFinish(false);
        }
    }

    public void PlayerMove(Vector3 position)
    {
        transform.position = position;
        gameplayManager.isPlayerMovable = false;
        gameplayManager.UpdatePhase(GamePhase.enemy);
    }

    public void ActivateCheckBox()
    {
        StartCoroutine(OpenAndCloseCheckBox(0.1f));
    }

    IEnumerator OpenAndCloseCheckBox(float waitTime)
    {
        checkBoxs.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        checkBoxs.SetActive(false);
    }

}
