using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameStart;
    public static event Action<float> OnGameEnd;

    
    [SerializeField] private GameObject startPanel;
    [SerializeField] private ScoreManager scoreManager;
    
    private float _startTime;
    private bool _isGameRunning = false;
    
    void Start()
    {
        ShowStartMenu();
    }

    public void OnStartButtonPressed()
    {
        startPanel.SetActive(false);
        StartGameplay();
    }

    public void StartGameplay()
    {
        _startTime = Time.time;
        _isGameRunning = true;
        OnGameStart?.Invoke();
    }

    public void CompleteGameplay()
    {
        if (!_isGameRunning) return;
        
        float timeTaken = Time.time - _startTime;
        _isGameRunning = false;

        scoreManager.SetScore(timeTaken);
        scoreManager.HighScoreUpdate();
        OnGameEnd?.Invoke(timeTaken);
    }

    private void ShowStartMenu()
    {
        startPanel.SetActive(true);
    }
}
