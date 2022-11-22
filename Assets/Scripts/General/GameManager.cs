using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Title,
    GameStart,
    LevelStart,
    Level,
    LevelEnd,
    PlayerDead,
    GameEnd
}

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int PointsAtDeath = 10;

    public GameState GameState { get; set; } = GameState.Title;
    public int TotalScore { get; set; } = 0; 
    public int Score { get; set; } = 0;

    private float gameTimer = 0f;

    private void Start()
    {
        GameState = GameState.Title;
    }

    private void Update()
    {
        gameTimer -= Time.deltaTime;

        switch (GameState)
        {
            case GameState.Title:
                OnTitle();
                break;
            case GameState.GameStart:
                OnGameStart();
                break;
            case GameState.LevelStart:
                OnLevelStart();
                break;
            case GameState.Level:
                OnLevel();
                break;
            case GameState.PlayerDead:
                OnPlayerDead();
                break;
            case GameState.LevelEnd:
                OnLevelEnd();
                break;
            case GameState.GameEnd:
                OnGameEnd();
                break;
        }
    }

    private void OnTitle()
    {
        if (gameTimer > 0)
            return;
    }

    private void OnGameStart()
    {
        if (gameTimer > 0)
            return;
    }

    private void OnLevelStart()
    {
        if (gameTimer > 0)
            return;
    }

    private void OnLevel() 
    {
        if (gameTimer > 0)
            return;
    }

    private void OnPlayerDead()
    {
        if (gameTimer > 0)
            return;

        StartCoroutine(nameof(SubtractPoints));
    }

    public void OnLevelEnd() 
    {
        if (gameTimer > 0)
            return;
    }

    private void OnGameEnd()
    {
        if (gameTimer > 0)
            return;
    }

    private IEnumerable SubtractPoints()
    {
        yield return new WaitForSeconds(5f);
    }
}
