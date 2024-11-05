using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void ResumeGame()
    {
        Toggle();
    }

    public void RestartGame()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Qutting Game");
        Application.Quit();
    }
}
