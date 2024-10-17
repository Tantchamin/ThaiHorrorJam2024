using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    public void Move(Vector3 position)
    {
        StartCoroutine(MoveToDestination(position));
        transform.LookAt(new Vector3(position.x, transform.position.y, position.z));
    }

    private IEnumerator MoveToDestination(Vector3 destination)
    {
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
    }
}
