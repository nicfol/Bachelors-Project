using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour {

    public void GoToAchievements()
    {
        SceneManager.LoadScene("Achievements");
    }
    public void GoToLearnCPR()
    {
        SceneManager.LoadScene("LearnCPR");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
