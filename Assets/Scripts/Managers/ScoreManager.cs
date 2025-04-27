using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    private Score score;
    private ScoreUI view;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    void Start()
    {
        score = new Score();
        view = FindObjectOfType<ScoreUI>();
        UpdateUI();
    }

    public void SetScore(float time)
    {
        score.SetScore(time);
        HighScoreUpdate();
        UpdateUI();
    }

    public void ResetScore()
    {
        score.ResetScore();
        UpdateUI();
    }

    public void HighScoreUpdate()
    {
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (score.CurrentScore > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetFloat("SavedHighScore", score.CurrentScore);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("SavedHighScore", score.CurrentScore);
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        view.UpdateScore(score.CurrentScore, score.HighScore);
    }
}
