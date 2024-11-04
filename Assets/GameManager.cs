using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameOver = false;

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
    }
}
