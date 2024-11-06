using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWon : MonoBehaviour
{
    public string menuSceneName = "MenuScene";

    public string nextLevel = "Level_02";
    public int levelToUnlock = 2;

    public void NextLevel()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene(nextLevel);
    }

    public void MainMenuLoader()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
