using TMPro;
using UnityEngine;

public class ScoreViewUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    public void Setup(int defaultValue = 0)
    {
        UpdateScoreText(defaultValue);
        PlayerPrefs.SetInt("Score", defaultValue);
    }

    public void UpdateScoreText(int newValue)
    {
        scoreText.text = $"Score: {newValue}";
        PlayerPrefs.SetInt("Score", newValue);
    }
}
