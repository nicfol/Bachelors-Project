using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void GoToLearnCPR()
    {
        SceneManager.LoadScene("LearnCPR");
    }
    
    public void GoToChallenges()
    {
        SceneManager.LoadScene("Challenges");
    }

    public void GoToAchievements()
    {
        SceneManager.LoadScene("Achievements");
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
