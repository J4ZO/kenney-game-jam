using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private LevelController levelController;
    [SerializeField] private PigController pig;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private int nextScene;
    
    [Header("Input Actions")]
    [SerializeField] private InputActionReference pauseAction;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        if (pig.loseGame)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }


        if (pauseAction.action.WasPressedThisFrame())
        {
            TooglePause();
            
        }
    }

    private void TooglePause()
    {
        if (pause.activeSelf) 
        {
            Time.timeScale = 1;
            pause.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pause.SetActive(true);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        pig.loseGame = false;
        pig.ResetValues();
        pause.SetActive(false);
        gameOver.SetActive(false);
    }
    
    public void TimeStart()
    {
        Time.timeScale = 1;
    }

    public void ChangeScene()
    {
        levelController.ChangeScene(nextScene);
    }
}
