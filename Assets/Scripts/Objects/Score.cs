using UnityEngine;

public class Score : MonoBehaviour
{
    public float CurrentScore { get; private set; }
    public float HighScore { get;  set; }

   
    public void SetScore(float time)
    {
        CurrentScore = time;
    }

    public void ResetScore()
    {
        CurrentScore = 0;
    }
}
