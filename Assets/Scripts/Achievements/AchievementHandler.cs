using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AchievementHandler : MonoBehaviour {

    private AchievementPopup achievementPopup;
    public static bool achievementsLoaded = false;
    private bool subcategoriesVisited;

    // Use this for initialization
    void Start () {
        achievementPopup = gameObject.GetComponent<AchievementPopup>();

        if (!achievementsLoaded)
        {
            Data.InitializeAchievements();
            achievementsLoaded = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        // Achievement 1 and 2 get unlocked in the Playe


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

        // Remember to set the booleans TRUE in Learn CPR scene.
        // Unlock Achievement 6 when user has visited all subcategories in the LearnCPR scene
        if (!Data.ach6.isUnlocked)
        {
            if (Data.LearnCPRVisited[0] && Data.LearnCPRVisited[1] && Data.LearnCPRVisited[2])
            {
                Data.ach6.isUnlocked = true;
                achievementPopup.DisplayPopup(Data.ach6.Name);
            }
        }

        // Achievement 7 is unlocked in the EndScenario script


    }
}