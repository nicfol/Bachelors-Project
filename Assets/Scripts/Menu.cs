using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void GoToAchievements()
    {
        SceneManager.LoadScene("Achievements");
    }
    public void GoToLearnCPR()
    {
        SceneManager.LoadScene("LearnCPR");
    }

    public void GoToFacts()
    {
        SceneManager.LoadScene("Facts");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
