using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        Option,
        GameOver
    }
    public GameState currentState;
    public Player player;
    private float playerSpeedIndex;
    [HideInInspector] public int currentFrameCount;
    public int currentSceneCount;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayButton()
    {
        ChangeState(GameState.Playing);
    }
    public void RestartButton()
    {
        SceneLoadeManager.instance.LoadSceneByName("Game");
    }
    public void GoToMainMenu()
    {
        SceneLoadeManager.instance.LoadSceneByName("MainMenu");
        instance.ChangeState(GameManager.GameState.MainMenu);
    }
    public void ChangeState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case GameState.MainMenu:
                break;
            case GameState.Playing:
                Time.timeScale = 1;
                player.canChangeState = true;
                player.moveSpeed = playerSpeedIndex;
                break;
            case GameState.Paused:
                Time.timeScale = 1;
                player.canChangeState = false;
                playerSpeedIndex = player.moveSpeed;
                player.moveSpeed = 0;
                break;
            case GameState.Option:
                Time.timeScale = 0;
                playerSpeedIndex = player.moveSpeed;
                player.moveSpeed = 0;
                break;
            case GameState.GameOver:
                Time.timeScale = 0;
                break;
        }
    }
}
