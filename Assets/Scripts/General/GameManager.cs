using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eGameState
{
    Title,
    GameStart,
    LevelStart,
    Level,
    LevelEnd,
    GameEnd,
    Win
}

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
