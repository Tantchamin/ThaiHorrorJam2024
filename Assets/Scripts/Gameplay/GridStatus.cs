using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStatus : MonoBehaviour
{
    public bool isSelected = false;
    public bool isSelectable = false;
    public List<GridStatus> connectedGrids;
    private Renderer objRenderer;
    private Color originalColor;
    public Color hoverColor = Color.red;  // Color when hovered
    private GameManager gameManager;
    private GridManager gridManager;

    public void Init(GameManager gameManager, GridManager gridManager)
    {
        this.gameManager = gameManager;
        this.gridManager = gridManager;
    }

    void Start()
    {
        // Get the Renderer component of the GameObject
        objRenderer = GetComponent<Renderer>();
        // Store the original color of the object
        originalColor = objRenderer.material.color;
    }

    private void OnMouseDown()
    {
        if (isSelectable)
            SelectGrid();
            objRenderer.material.color = originalColor;
    }

    public void SelectGrid()
    {
        Player player = gameManager.player;
        player.transform.position = transform.position;
        gridManager.ResetSelectableGrid();
        foreach(GridStatus grid in connectedGrids)
        {
            grid.isSelectable = true;
        }
    }

    void OnMouseEnter()
    {
        if(isSelectable)
            objRenderer.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        objRenderer.material.color = originalColor;
    }
}
