using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject optionsObject;
    
    [SerializeField] private AudioSource pauseSound;

    private bool isPaused = false;
    public bool IsPaused 
    {
        get { return isPaused; }
        set 
        { 
            isPaused = value;
            pauseUI.SetActive(isPaused);
            Time.timeScale = isPaused ? 0f : 1f;
        } 
    }

    private void Start()
    {
        pauseUI.SetActive(false);
    }

    public void OnPause()
    {
        if (pauseSound != null)
            pauseSound.Play();
        
        IsPaused = !IsPaused;
    }

    public void Resume()
    {
        if (pauseSound != null)
            pauseSound.Play();
        
        IsPaused = false;
    }

    public void Options()
    {
        //optionsObject.SetActive(true);
        //pauseUI.SetActive(false);
    }

    public void Exit()
    {
        IsPaused = false;
        GameManager.Instance.GameState = GameState.Title;
    }
}
