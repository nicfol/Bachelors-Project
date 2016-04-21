using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementHandler : MonoBehaviour {

    //public GameObject checkmark_1;
    //public Strings strings;
    private Achievements achievements;

    private AchievementPopup achievementPopup;

    // Use this for initialization
    void Start () {
        achievements = GetComponent<Achievements>();
        achievementPopup = GetComponent<AchievementPopup>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Space!");
            achievements.ach_1.isUnlocked = true;
      
            Debug.Log("Achievement: '" + achievements.ach_1.Name + " ' has been unlocked. ");
            achievementPopup.DisplayPopup(achievements.ach_1.Name);
        }
    }


    
}


