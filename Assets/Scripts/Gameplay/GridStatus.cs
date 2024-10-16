using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStatus : MonoBehaviour
{
    public bool isSelected = false;
    public bool isSelectable = false;
    private Renderer objRenderer;
    private Color originalColor;
    public Color hoverColor = Color.red;  // Color when hovered
    private GameplayManager gameplayManager;
    private GridManager gridManager;

    public void Init(GameplayManager gameplayManager, GridManager gridManager)
    {
        this.gameplayManager = gameplayManager;
        this.gridManager = gridManager;
    }

    void Start()
    {
        // Get the Renderer component of the GameObject
        objRenderer = GetComponent<Renderer>();
        // Store the original color of the object
        originalColor = objRenderer.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("GridChecker"))
        {
            isSelectable = true;
        }
    }

    private void OnMouseDown()
    {
        if (isSelectable)
            SelectGrid();
            objRenderer.material.color = originalColor;
    }

    public void SelectGrid()
    {
        Player player = gameplayManager.player;
        player.transform.position = transform.position;
        gridManager.ResetSelectableGrid();
        player.PlayerMove(transform.position);

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
