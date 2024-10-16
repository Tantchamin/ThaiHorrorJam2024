using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GamePhase
{
    player,
    enemy,
    result,
    end
}

public class GameplayManager : MonoBehaviour
{
    public Player player;
    public GridManager gridManager;

    // Start is called before the first frame update
    void Start()
    {
        gridManager.InitGrids();
        gridManager.grids[0].SelectGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePhase(GamePhase phase)
    {
        switch (phase)
        {
            case GamePhase.player:
                
                break;
            case GamePhase.enemy:
                StartCoroutine(WaitAndChangePhase(1, GamePhase.result));
                break;
            case GamePhase.result:
                StartCoroutine(WaitAndChangePhase(1, GamePhase.end));
                break;
            case GamePhase.end:
                StartCoroutine(WaitAndChangePhase(1, GamePhase.player));
                break;
        }
    }

    IEnumerator WaitAndChangePhase(float waitTime, GamePhase nextPhase)
    {
        yield return new WaitForSeconds(waitTime);
        UpdatePhase(nextPhase);
    }
}
