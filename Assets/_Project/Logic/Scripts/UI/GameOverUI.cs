using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private ScoreViewUI scoreViewUI;

    private void Start()
    {
        scoreViewUI.Setup(PlayerPrefs.GetInt("Score"));
    }

    public void OnRetryButtonClick()
    {
        SceneManager.LoadScene("GameplayScene", LoadSceneMode.Single);
    }

    public void OnBackToMenuButtonClick()
    {
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }
}
