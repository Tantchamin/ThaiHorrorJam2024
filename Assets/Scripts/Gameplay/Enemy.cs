using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<GridStatus> movePathGrids;
    [SerializeField] private bool isLoop = false;
    private int moveCount = 0;

    public void Move()
    {
        if (moveCount + 1 == movePathGrids.Count)
        {
            if (!isLoop) movePathGrids.Reverse();
            moveCount = isLoop? -1 : 0;
        }

        moveCount++;
        transform.position = movePathGrids[moveCount].transform.position;
    }
}
