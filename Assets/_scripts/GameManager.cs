using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;

    public GameObject gameOverMenu;

    public GameObject completeLevelUI;

    void Start()
    {
        gameOver = false;
    }

    void Update()
    {
        if (PlayerStats.Lives <= 0 && !gameOver)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("Game Over");
        gameOver = true;

        gameOverMenu.SetActive(true);
    }

    public void WinLevel()
    {
        gameOver = true;
        completeLevelUI.SetActive(true);
    }
}
