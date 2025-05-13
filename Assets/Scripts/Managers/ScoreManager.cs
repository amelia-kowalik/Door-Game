using System;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ScoreUI view;
    private Score score;
    private string path;
    
    
    void Start()
    {
        path = Application.persistentDataPath + "/score.json";
        Debug.Log(path);
        
        LoadHighScore();
        
        UpdateUI();
    }

    public void SetScore(float time)
    {
        score.SetScore(time);
        
        if (score.currentScore < score.highScore)
        {
            score.highScore = score.currentScore;
            
        }
        SaveToJson();
        UpdateUI();
    }

    public void ResetScore()
    {
        score.ResetScore();
        UpdateUI();
    }

    private void LoadHighScore()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            score = JsonUtility.FromJson<Score>(json);
        }
        else
        {
            score.highScore = float.MaxValue;
            SaveToJson();
        }

    }

    public void SaveToJson()
    {
        string scoreData = JsonUtility.ToJson(score);
        Debug.Log("Serialized score data: " + scoreData);
        File.WriteAllText(path, scoreData);
        Debug.Log("Saved score to json");
    }

    public void UpdateUI()
    {
        view.UpdateScore(score.currentScore, score.highScore);
    }
}
