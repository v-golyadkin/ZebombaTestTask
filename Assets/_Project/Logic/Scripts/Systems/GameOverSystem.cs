using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSystem : Singleton<GameOverSystem>
{
    public void CheckGameOver()
    {
        if (MatchSystem.Instance.GetCirclesCount() == 9 && !MatchSystem.Instance.IsMatch)
            GameOver();
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
    }

    [ContextMenu("TestGameOver")]
    private void TestGameOver()
    {
        GameOver();
    }
}
