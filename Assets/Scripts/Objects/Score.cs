[System.Serializable]
public class Score
{
    public float currentScore;
    public float highScore;
    
    public void SetScore(float time)
    {
        currentScore = time;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
