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
    public GameplayUiManager gameplayUiManager;
    private bool isFinish = false;
    private bool isWin = false;
    public bool isPlayerMovable = true;
    private int star = 0;

    void Start()
    {
        player.Init(this);
        gridManager.InitGrids();
        gridManager.grids[0].SelectGrid();
        player.ActivateCheckBox();
    }

    public void UpdatePhase(GamePhase phase)
    {
        switch (phase)
        {
            case GamePhase.player:
                isPlayerMovable = true;
                player.ActivateCheckBox();
                break;
            case GamePhase.enemy:
                if (isFirstTime)
                {
                    isFirstTime = false;
                    isPlayerMovable = true;
                    return;
                }
                enemyManager.MoveAllEnemy();
                StartCoroutine(WaitAndChangePhase(1, GamePhase.result));
                break;
            case GamePhase.result:
                if(isFinish)
                {
                    gameplayUiManager.OpenFinishUi(isWin);
                    return;
                }
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

    public void GameFinish(bool isWin)
    {
        isFinish = true;
        this.isWin = isWin;
    }

    public void CollectStar()
    {
        gameplayUiManager.CollectStar(star);
        star++;
    }
}
