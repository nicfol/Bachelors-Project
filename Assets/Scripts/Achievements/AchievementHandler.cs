using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AchievementHandler : MonoBehaviour {

    private AchievementPopup achievementPopup;
    public static bool achievementsLoaded = false;
    private bool subcategoriesVisited;
    private PlayerController playerController;
    bool playerControllerFound;

    // Use this for initialization
    void Start () {
        achievementPopup = gameObject.GetComponent<AchievementPopup>();

        if (!achievementsLoaded)
        {
            Data.InitializeAchievements();
            achievementsLoaded = true;
        }

        // Check if we can find a Scenario Handler (used to detect if we are in a scenario or not)
        if(GameObject.Find("Scenario Handler") != null)
        {
            playerController = GameObject.Find("Scenario Handler").GetComponent<PlayerController>();
            playerControllerFound = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

        // Check if playercontroller was found in order to detect if we are in a Scenario scene
        if (playerControllerFound)
        {
            // Check if we have answered the last question in the scenario
            if (playerController.endOfScenario)
            {
                // Unlock achievement 1 if we complete a scenario
                if (!Data.ach1.isUnlocked)
                {
                    Data.ach1.isUnlocked = true;
                    achievementPopup.DisplayPopup(Data.ach1.Name);
                }

                // Unlock achievement 2 if we complete the 2nd scenario
                if (!Data.ach2.isUnlocked && SceneManager.GetActiveScene().name == "Scenario 2")
                {
                    Data.ach2.isUnlocked = true;
                    achievementPopup.DisplayPopup(Data.ach2.Name);
                }

                // Unlock achievement 7 if we have all the answers correct without any errors.
                if (!Data.ach7.isUnlocked)
                {
                    if (playerController.noWrongAnswer)
                    {
                        Data.ach7.isUnlocked = true;
                        achievementPopup.DisplayPopup(Data.ach7.Name);
                    }
            }
            }

            // Unlock achievement 8 when user gets 3 correct in a row
            if (!Data.ach8.isUnlocked)
            {
                if (playerController.correctAnswerStreak >= 3)
                {
                    Data.ach8.isUnlocked = true;
                    achievementPopup.DisplayPopup(Data.ach8.Name);
                }
            }

            // Unlock achievement 9 when user gets 6 correct in a row
            if (!Data.ach9.isUnlocked)
            {
                if (playerController.correctAnswerStreak >= 6)
                {
                    Data.ach9.isUnlocked = true;
                    achievementPopup.DisplayPopup(Data.ach9.Name);
                }
            }
        } // End of playerControllerFound

        // Unlock Achievement 3 when user enters Facts scene
        if(SceneManager.GetActiveScene().name == "Facts")
        {
            if (!Data.ach3.isUnlocked)
            {
                Data.ach3.isUnlocked = true;
                achievementPopup.DisplayPopup(Data.ach3.Name);
            }
        }

        // Unlock Achievement 4 when user reaches 50%
        if (!Data.ach4.isUnlocked)
        {
            if (Data.Progression >= 50)
            {
                Data.ach4.isUnlocked = true;
                achievementPopup.DisplayPopup(Data.ach4.Name);
            }
        }

        // Unlock Achievement 5 when user reaches 100%
        if (!Data.ach5.isUnlocked)
        {
            if (Data.Progression >= 100)
            {
                Data.ach5.isUnlocked = true;
                achievementPopup.DisplayPopup(Data.ach5.Name);
            }
        }

        // Unlock Achievement 6 when user has visited all subcategories in the LearnCPR scene
        if (!Data.ach6.isUnlocked)
        {
            if (Data.LearnCPRVisited[0] && Data.LearnCPRVisited[1] && Data.LearnCPRVisited[2])
            {
                Data.ach6.isUnlocked = true;
                achievementPopup.DisplayPopup(Data.ach6.Name);
            }
        }

    }
}