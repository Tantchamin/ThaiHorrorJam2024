using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<GridStatus> movePathGrids;
    [SerializeField] private bool isLoop = false;
    [SerializeField] private UnitMove unitMove;
    private int moveCount = 0;

    public void Move()
    {
        if (moveCount + 1 == movePathGrids.Count)
        {
            if (!isLoop) movePathGrids.Reverse();
            moveCount = isLoop? -1 : 0;
        }

        moveCount++;
        unitMove.Move(movePathGrids[moveCount].transform.position);
    }

}
