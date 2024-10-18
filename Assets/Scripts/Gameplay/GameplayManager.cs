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
    [SerializeField] private int conditionTurnCount = 0;
    private int turnCount = 1; 
    private bool isFirstTime = true;
    public Player player;
    public GridManager gridManager;
    public EnemyManager enemyManager;
    public GameplayUiManager gameplayUiManager;
    private bool isFinish = false;
    private bool isWin = false;
    public bool isPlayerMovable = true;
    public int star = 0;
    public int stageNumber = 0;
    public bool isChat = false;
    private SoundManager soundManager;

    private void Awake()
    {
        stageNumber = PlayerPrefs.GetInt("stage");
        soundManager = SoundManager.GetInstance();
    }

    void Start()
    {
        player.Init(this);
        gridManager.InitGrids();
        gridManager.grids[0].SelectGrid();
        player.ActivateCheckBox();
        gameplayUiManager.TurnAdjust(turnCount);
        soundManager.PlayBgm("PlayBGM1", true);
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
                if (isFinish)
                {
                    gameplayUiManager.OpenFinishUi(isWin);
                    ScoreData.SetStar(star, stageNumber);
                    SaveLoadData.SaveScoreData();
                    return;
                }
                UpdatePhase(GamePhase.end);
                break;
            case GamePhase.end:
                turnCount++;
                gameplayUiManager.TurnAdjust(turnCount);
                UpdatePhase(GamePhase.player);
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
        if(isWin) GetStar(0);
        if (turnCount <= conditionTurnCount)
        {
            GetStar(2);
        }
        isFinish = true;
        this.isWin = isWin;
    }

    public void CollectStar()
    {
        GetStar(1);
    }

    public void GetStar(int starOrder)
    {
        gameplayUiManager.CollectStar(starOrder);
        star++;
    }
}
