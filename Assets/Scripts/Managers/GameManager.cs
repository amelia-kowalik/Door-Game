using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameStart;
    public static event Action<float> OnGameEnd;
    
    public static GameManager Instance { get; private set; }
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private PopUpManager popUpManager;

    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;
    
    private float _startTime;
    private bool _isGameRunning = false;
    
    public ScoreManager ScoreManager => scoreManager;
    public PopUpManager PopUpManager => popUpManager;
    
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

        ScoreManager.SetScore(timeTaken);
        ScoreManager.HighScoreUpdate();
        gameOverPanel.SetActive(true);
        
        OnGameEnd?.Invoke(timeTaken);
    }

    public void StartAgain()
    {
        ScoreManager.HighScoreUpdate();
            
        ScoreManager.ResetScore();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ShowStartMenu()
    {
        startPanel.SetActive(true);
    }
}
