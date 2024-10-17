using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject checkBoxs;
    private GameplayManager gameplayManager;
    private bool isMove = false;

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
        if (!isMove)
        {
            StartCoroutine(MoveToDestination(position));
        }
        isMove = true;
        transform.LookAt(new Vector3(position.x, transform.position.y, position.z));
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

    private IEnumerator MoveToDestination(Vector3 destination)
    {
        isMove = true;
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        float moveDuration = 1f;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, destination, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        transform.position = destination; // Ensure we set the position to the final destination
        isMove = false;
    }

}
