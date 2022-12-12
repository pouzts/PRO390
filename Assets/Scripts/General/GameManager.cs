using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
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
    [SerializeField] private GameObject pauseObject;
    [SerializeField] private SceneTransition sceneTransition;
    
    [SerializeField] private int pointsAtDeath = 10;
    
    [SerializeField] private string titleSceneName;
    [SerializeField] private string deathSceneName;

    public GameState GameState { get; set; } = GameState.Title;

    public bool CanPause { get; set; } = false;
    
    public int TotalScore { get; set; }

    private int score = 0;
    public int Score 
    {
        get { return score; }
        set 
        {
            score = value;

            if (score <= 0)
                score = 0;
        } 
    }

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

        FindObjectOfType<PlayerSpawner>().SpawnPlayer();
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

        StartCoroutine(SubtractPoints());
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

    private IEnumerator SubtractPoints()
    {
        sceneTransition.TransitionScene(deathSceneName);

        for (int i = 0; i > pointsAtDeath; i++)
        {
            Score -= i;
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }
}
