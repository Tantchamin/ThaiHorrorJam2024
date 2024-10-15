using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private Renderer objRenderer;
    private Color originalColor;
    public Color hoverColor = Color.red;  // Color when hovered

    void Start()
    {
        // Get the Renderer component of the GameObject
        objRenderer = GetComponent<Renderer>();
        // Store the original color of the object
        originalColor = objRenderer.material.color;
    }

    private void OnMouseDown()
    {
        Debug.Log(name);
    }

    void OnMouseEnter()
    {
        // Change the object's color when the mouse enters its collider
        objRenderer.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        // Revert to the original color when the mouse exits
        objRenderer.material.color = originalColor;
    }
}
