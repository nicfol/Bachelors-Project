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

    public void ReloadCurrentScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void GoToScenario1()
    {
        SceneManager.LoadScene("Scenario 1");
    }
    
    public void GoToScenario2()
    {
        SceneManager.LoadScene("Scenario 2");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
    public void GoToBasicCPR()
    {
        SceneManager.LoadScene("BasicCPR");
    }

    public void GoToAED()
    {
        SceneManager.LoadScene("AED");
    }

    public void GoToRecoveryPos()
    {
        SceneManager.LoadScene("RecoveryPos");
    }
    
    
}
