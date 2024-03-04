using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameStates gameState { get; set; }
    public event Action<GameStates> OnGameStateChanged;

    private void Awake()
    {
        instance = this;
        UpdateGameState(GameStates.Gameplay);
    }

    public void UpdateGameState(GameStates newState)
    {
        gameState = newState;
        OnGameStateChanged?.Invoke(newState);
    }
}
public enum GameStates
{
    Gameplay,
    Win,
    Die
}