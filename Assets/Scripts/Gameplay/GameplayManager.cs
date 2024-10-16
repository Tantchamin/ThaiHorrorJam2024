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
    private bool isFirstTime = true;
    public Player player;
    public GridManager gridManager;
    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        player.Init(this);
        gridManager.InitGrids();
        gridManager.grids[0].SelectGrid();
        player.ActivateCheckBox();
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
                player.ActivateCheckBox();
                break;
            case GamePhase.enemy:
                if (isFirstTime)
                {
                    isFirstTime = false;
                    return;
                }
                enemyManager.MoveAllEnemy();
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
