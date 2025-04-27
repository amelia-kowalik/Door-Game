using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameStart;
    public static event Action<float> OnGameEnd;
    
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;
    
    private float _startTime;
    private bool _isGameRunning = false;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; }
        else
        {
            Destroy(gameObject); 
        }
    }
    
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

        ScoreManager.Instance.SetScore(timeTaken);
        ScoreManager.Instance.HighScoreUpdate();
        gameOverPanel.SetActive(true);
        
        OnGameEnd?.Invoke(timeTaken);
    }

    public void StartAgain()
    {
        ScoreManager.Instance.HighScoreUpdate();
            
        ScoreManager.Instance.ResetScore();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ShowStartMenu()
    {
        startPanel.SetActive(true);
    }
}
