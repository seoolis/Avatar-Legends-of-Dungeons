using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int gameSceneIndex;
    [SerializeField] private GameObject aboutPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }

    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }

    public void ShowAboutPanel()
    {
        aboutPanel.SetActive(true);
    }

    public void CloseAboutPanel()
    {
        aboutPanel.SetActive(false);
    }

    public void BackButton()
    {
        if (aboutPanel.activeSelf)
            CloseAboutPanel();
    }
}