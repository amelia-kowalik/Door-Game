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
        LoadHighScore();
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

    private void LoadHighScore()
    {
        score.HighScore = PlayerPrefs.HasKey("SavedHighScore") ? PlayerPrefs.GetFloat("SavedHighScore") : 0;
        if (!PlayerPrefs.HasKey("SavedHighScore"))
        {
            PlayerPrefs.SetFloat("SavedHighScore", 0);
            PlayerPrefs.Save();
        }
    }

    public void HighScoreUpdate()
    {
        float savedHighScore = PlayerPrefs.GetFloat("SavedHighScore", 0);

        if (score.CurrentScore < savedHighScore) 
        {
            PlayerPrefs.SetFloat("SavedHighScore", score.CurrentScore);
            score.HighScore = score.CurrentScore;
            PlayerPrefs.Save(); 
        }
        else
        {
            score.HighScore = savedHighScore;
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        view.UpdateScore(score.CurrentScore, score.HighScore);
    }
}
