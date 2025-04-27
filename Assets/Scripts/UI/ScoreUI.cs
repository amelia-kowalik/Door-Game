using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;

    public void UpdateScore(float current, float high)
    {
        currentScoreText.text = $"Time: {current:F2}";
        highScoreText.text = $"Best time: {high:F2}";
    }
}
