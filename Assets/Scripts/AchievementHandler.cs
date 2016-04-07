using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementHandler : MonoBehaviour {

    public GameObject checkmark_1;

    public Achievements achievements;

    public AchievementPopup achievementPopup;

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
            checkmark_1.SetActive(true);
            Debug.Log("Achievement: '" + achievements.ach_1.Name + " ' has been unlocked. ");
            achievementPopup.DisplayPopup(achievements.ach_1.Name);
        }

        //achievements.achievementList

        foreach(Achievement a in achievements.achievementList)
        {
            

            //if(a.levelToUnlock == currentLevel )

        }


    }


    
}


