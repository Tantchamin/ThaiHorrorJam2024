using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public List<GridStatus> grids;
    public GridStatus selectedGrid;
    public GridStatus goalGrid;
    public GameplayManager gameplayManager;

    public void InitGrids()
    {
        for (int number = 0; number < grids.Count; number++)
        {
            grids[number].Init(gameplayManager, this);
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
