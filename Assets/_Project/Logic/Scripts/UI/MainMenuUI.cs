using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("GameplayScene", LoadSceneMode.Single);
    }
}
