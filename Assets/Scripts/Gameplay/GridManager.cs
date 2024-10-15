using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public List<GridStatus> grids;
    public GridStatus selectedGrid;
    public GameManager gameManager;

    private void Awake()
    {
        for (int number = 0; number < grids.Count; number++)
        {
            grids[number].Init(gameManager, this);
        }
    }

    public void ResetSelectableGrid()
    {
        for (int number = 0; number < grids.Count; number++)
        {
            grids[number].isSelectable = false;
        }
    }

}
