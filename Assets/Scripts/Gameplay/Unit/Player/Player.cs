using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject checkBoxs;
    [SerializeField] private UnitMove unitMove;
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
        else if (other.CompareTag("Star"))
        {
            gameplayManager.CollectStar();
            Destroy(other.gameObject);
        }
    }

    public void PlayerMove(Vector3 position)
    {
        unitMove.Move(position);
        gameplayManager.isPlayerMovable = false;
        StartCoroutine(WaitAndUpdate(1));
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

    IEnumerator WaitAndUpdate(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameplayManager.UpdatePhase(GamePhase.enemy);
    }

}
