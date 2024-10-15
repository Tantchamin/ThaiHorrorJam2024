using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public GridManager gridManager;

    // Start is called before the first frame update
    void Start()
    {
        gridManager.grids[0].SelectGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
