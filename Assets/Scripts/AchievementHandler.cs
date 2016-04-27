using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementHandler : MonoBehaviour {

    private Achievements achievements;
    private AchievementPopup achievementPopup;

    // Use this for initialization
    void Start () {
        achievements = gameObject.GetComponent<Achievements>();
        achievementPopup = gameObject.GetComponent<AchievementPopup>();
        

    }
	
	// Update is called once per frame
	void Update () {
        if (!Data.ach2.isUnlocked)
        {
            Data.ach2.isUnlocked = true;
            achievementPopup.DisplayPopup(Data.ach2.Name);
        }
    }


    
}


