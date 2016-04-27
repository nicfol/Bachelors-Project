using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AchievementHandler : MonoBehaviour {

    private Achievements achievements;
    private AchievementPopup achievementPopup;
    bool achievementsLoaded = false;

    // Use this for initialization
    void Start () {
        achievements = gameObject.GetComponent<Achievements>();
        achievementPopup = gameObject.GetComponent<AchievementPopup>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!achievementsLoaded)
        {
            Data.InitializeAchievements();
            achievementsLoaded = true;
        }

        if(SceneManager.GetActiveScene().name == "Facts")
        {
            if (!Data.ach2.isUnlocked)
            {
                Data.ach2.isUnlocked = true;
                achievementPopup.DisplayPopup(Data.ach2.Name);
            }
        }

        if (SceneManager.GetActiveScene().name == "Achievements")
        {
            if (!Data.ach3.isUnlocked)
            {
                Data.ach3.isUnlocked = true;
                achievementPopup.DisplayPopup(Data.ach3.Name);
            }
        }
    }


    
}


