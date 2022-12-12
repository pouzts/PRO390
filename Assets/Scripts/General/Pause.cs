using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject optionsObject;
    
    [SerializeField] private AudioSource pauseSound;

    private PlayerControls playerControls;

    private InputAction pauseAction;
    
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

    private void Awake()
    {
        playerControls = new();
        pauseUI.SetActive(false);
    }
    
    private void OnEnable()
    {
        pauseAction = playerControls.Pause.Pause;
        pauseAction.Enable();
        pauseAction.performed += OnPause;
    }

    private void OnDisable()
    {
        pauseAction.performed -= OnPause;
        pauseAction.Disable();
    }

    public void OnPause(InputAction.CallbackContext callbackContext)
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

    public void ExitToTitle()
    {
        IsPaused = false;
        GameManager.Instance.GameState = GameState.Title;
    }
}
